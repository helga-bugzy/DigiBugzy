﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DigiBugzy.Desktop.Administration.Categories
{
    public partial class CategoriesManager : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private int _classificationId;

        private List<Category> Categories { get; set; } = new();

        private Category SelectedCategory { get; set; } = new();

        private bool _isDragging { get; set; }


        #endregion

        #region Ctor

        public CategoriesManager(int classificationId =0)
        {
            _classificationId = classificationId;
            InitializeComponent();

            LoadClassifications();
            LoadCategories();
            LoadCategoryEditor();
        }

        #endregion

        #region Public Methods

        

        #endregion

        #region Helper Methods

        private void ApplyFilter()
        {
            _classificationId = cmbClassifications.SelectedIndex < 0 ? 0 : (cmbClassifications.SelectedItem as Classification)!.Id;

            //Reload data
            LoadCategories();
            SelectedCategory = new Category();
            LoadCategoryEditor();
            Application.DoEvents();
        }

        private void LoadClassifications()
        {
            using var service = new ClassificationService(Globals.GetConnectionString());

            var collection = service.Get(new StandardFilter { DigiAdminId = Globals.DigiAdministration.Id });
            cmbClassifications.Items.Clear();
            cmbClassifications.DataSource = collection;
            cmbClassifications.DisplayMember = "Name";
            cmbClassifications.ValueMember = "Id";

            if (_classificationId > 0)
            {
                foreach (var item in cmbClassifications.Items)
                {
                    if (item is not Classification classification || classification.Id != _classificationId) continue;
                    cmbClassifications.SelectedItem = item;
                    LoadCategories();
                    break;
                }
            }
            else
            {
                cmbClassifications.SelectedIndex = -1;
            }

            Application.DoEvents();
        }

        private void LoadCategories()
        {
            twCategories.Nodes.Clear();

            if (_classificationId <= 0)
            {
                twCategories.Enabled = false;
                Application.DoEvents();
                return;
            }

            twCategories.Enabled = true;

            
            if (_classificationId <= 0) return;

            using var service = new CategoryService(Globals.GetConnectionString());
            Categories = service.Get(new StandardFilter
            {
                ClassificationId = _classificationId, 
                DigiAdminId = Globals.DigiAdministration.Id,
                IncludeDeleted = chkIncludeDeleted.Checked, 
                IncludeInActive = chkFilterInactive.Checked
            });
            
            if (Categories.Count <= 0) return;

            LoadCategoryNodes();

        }

        private void LoadCategoryNodes()
        {

          
            //Get all parents
            var parents = (from c in Categories
                    where c.ParentId == null
                    select new Category
                    {
                        Id = c.Id, 
                        ParentId = c.ParentId, 
                        Name = c.Name, 
                        IsActive = c.IsActive, 
                        IsDeleted = c.IsDeleted
                    })
                .ToList();
            
            //Loop and add
            foreach (var parent in parents)
            {
                var node = new TreeNode(text: parent.Name)
                {
                    Tag = parent.Id,
                    NodeFont = CreateFont(parent.IsDeleted, parent.IsActive)
                };
                LoadCategoryNodes(node);

                node.Text = $@"{parent.Name} ({node.Nodes.Count} subs)";

                twCategories.Nodes.Add(node);
            }
            

        }

        private void LoadCategoryNodes(TreeNode? parentNode)
        {
            if (parentNode == null) return;
            var children = Categories
                .Where(c => c.ParentId == int.Parse(parentNode.Tag.ToString()!))
                .Select(c => new Category
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    IsDeleted = c.IsDeleted
                })
                .ToList();

            if (children.Count > 0)
            {

                foreach (var child in children)
                {
                   

                    var node = new TreeNode(text: child.Name)
                    {
                        Tag = child.Id,
                        NodeFont = CreateFont(child.IsDeleted, child.IsActive)
                    };

                    parentNode.Nodes.Add(node);

                    LoadCategoryNodes(node);
                }
            }
        }

        private void LoadCategoryEditor()
        {
            if (_classificationId <= 0)
            {
                pnlEditor.Visible = false;
                Application.DoEvents();
                return;
            }

            pnlEditor.Visible = true;

            if(SelectedCategory.Id <= 0)
            {
                txtDescription.Text = txtName.Text = string.Empty;
                chkActive.Checked = true;
                lblHeading.Text = @"New Category";

            }
            else
            {
                txtName.Text = SelectedCategory.Name;
                txtDescription.Text = SelectedCategory.Description;
                chkActive.Checked = true;
                lblHeading.Text = $@"Edit {SelectedCategory.Name} (ID: {SelectedCategory.Id})";

            }

            LoadCategoryEditorParents();

            Application.DoEvents();
        }

        private void LoadCategoryEditorParents()
        {
            cmbParents.Visible = chkParent.Checked = false;

            using var service = new CategoryService(Globals.GetConnectionString());
            var collection = service.Get(new StandardFilter { OnlyParents = true, DigiAdminId = Globals.DigiAdministration.Id});
            var source = collection.Where(x => x.Id != SelectedCategory.Id).ToList();

            if (SelectedCategory.Id <= 0)
            {
                cmbParents.SelectedItem = -1;
            }
            else
            {
                if (SelectedCategory.ParentId > 0)
                {
                    cmbParents.Visible = chkParent.Checked = true;
                }
            }

            cmbParents.DataSource = source;
            cmbParents.DisplayMember = "Name";
            cmbParents.ValueMember = "Id";

            Application.DoEvents();

        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            try
            {
                while (true)
                {
                    // Check the parent node of the second node.  
                    if (node2.Parent == null) return false;
                    if (node2.Parent.Equals(node1)) return true;

                    // If the parent node is not null or equal to the first node,   
                    // call the ContainsNode method recursively using the parent of   
                    // the second node.  
                    node2 = node2.Parent;
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               return false;
            }
        }

        private Font CreateFont(bool isDeleted, bool isActive)
        {
            var font = new Font(twCategories.Font.FontFamily, twCategories.Font.Size);
            if (isDeleted)
            {
                font = new Font(font, FontStyle.Strikeout);
            }
            else if (!isActive)
            {
                font = new Font(font, FontStyle.Italic);
            }

            return font;

        }

        #endregion

        #region Control Event Procedures

        #region Filter

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cmbClassifications_SelectedIndexChanged(object sender, EventArgs e)
        {
           ApplyFilter();
        }

        private void chkFilterInactive_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void chkIncludeDeleted_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        #endregion

        #region Editor

        private void chkParent_CheckedChanged(object sender, EventArgs e)
        {
            cmbParents.Visible = chkParent.Checked;
            Application.DoEvents();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SelectedCategory = new Category();
            LoadCategoryEditor();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validations
                if (chkParent.Checked && cmbParents.SelectedIndex < 0)
                {
                    MessageBox.Show(@"Please select a valid parent or indicate that no parent is to be used.",
                        @"Validation Error", MessageBoxButtons.OK);
                    return;
                }

                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show(@"Please enter a name for the category", @"Validation Error", MessageBoxButtons.OK);
                    return;
                }


                //Set values
                if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    txtDescription.Text = txtName.Text;
                }

                SelectedCategory.ClassificationId = _classificationId;
                SelectedCategory.ParentId = chkParent.Checked ? (cmbParents.SelectedItem as Category)?.Id : null;
                SelectedCategory.Name = txtName.Text.Trim();
                SelectedCategory.Description = txtDescription.Text.Trim();
                SelectedCategory.IsActive = chkActive.Checked;
                SelectedCategory.IsDeleted = false;

                //Save
                using var service = new CategoryService(Globals.GetConnectionString());
                if (SelectedCategory.Id <= 0)
                {
                    SelectedCategory.CreatedOn = DateTime.Now;
                    SelectedCategory.DigiAdminId = Globals.DigiAdministration.Id;
                    service.Create(SelectedCategory);
                }
                else
                    service.Update(SelectedCategory);

                //Reload & reset values
                LoadCategories();
                SelectedCategory = new Category();
                LoadCategoryEditor();

                //Message
                //MessageBox.Show(@"Database has been updated and screen reloaded.", @"Save success",
                //    MessageBoxButtons.OK);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@$"Error saving category information: {exception.Message}");
            }
            finally
            {
                Application.DoEvents();
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedCategory.Id <= 0) return;
            using var service = new CategoryService(Globals.GetConnectionString());
            service.Delete(SelectedCategory.Id);

            LoadCategories();
            SelectedCategory = new Category();
            LoadCategoryEditor();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (SelectedCategory.Id <= 0) return;
            SelectedCategory.IsDeleted = false;
            SelectedCategory.IsActive = true;
            using var service = new CategoryService(Globals.GetConnectionString());
            service.Update(SelectedCategory);

            LoadCategories();
            //SelectedCategory = new Category();
            LoadCategoryEditor();
        }

        

        #endregion

        #region Treeview

        private void twCategories_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_isDragging) return;
            using var service = new CategoryService(Globals.GetConnectionString());
            SelectedCategory = service.GetById(int.Parse(e.Node.Tag.ToString()!));

            LoadCategoryEditor();

            Application.DoEvents();

        }

        private void twCategories_ItemDrag(object sender, ItemDragEventArgs e)
        {
            _isDragging = true;
            // Move the dragged node when the left mouse button is used.  
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item!, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.  
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item!, DragDropEffects.Copy);
            }
        }

        private void twCategories_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void twCategories_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            var targetPoint = twCategories.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            twCategories.SelectedNode = twCategories.GetNodeAt(targetPoint);
        }


        private void twCategories_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.  
            var targetPoint = twCategories.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.  
            var targetNode = twCategories.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.  
            var draggedNode = (TreeNode)e.Data!.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not   
            // the dragged node or a descendant of the dragged node.  
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current   
                // location and add it to the node at the drop location.  
                if (e.Effect == DragDropEffects.Move)
                {
                    SelectedCategory.ParentId = int.Parse(targetNode.Tag.ToString()!);
                    using var service = new CategoryService(Globals.GetConnectionString());
                    service.Update(SelectedCategory);
                    LoadCategoryEditor();

                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);

                    
                }

                // Expand the node at the location   
                // to show the dropped node.  
                targetNode.Expand();

                _isDragging = false;
            }

            Application.DoEvents();
        }

        private void twCategories_DragLeave(object sender, EventArgs e)
        {


        }





        #endregion

        #endregion

        
    }
}