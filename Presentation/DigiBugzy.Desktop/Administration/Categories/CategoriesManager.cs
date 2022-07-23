

using System.Collections.Generic;
using System.Linq;

namespace DigiBugzy.Desktop.Administration.Categories
{
    public partial class CategoriesManager : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private int _classificationId;

        private List<Category> Categories { get; set; } = new();

        private Category SelectedCategory { get; set; } = new();

        


        #endregion

        #region Ctor

        public CategoriesManager(int classificationId =0)
        {
            _classificationId = classificationId;
            InitializeComponent();

            LoadClassifications();
        }

        #endregion

        #region Public Methods

        

        #endregion

        #region Helper Methods

        private void LoadClassifications()
        {
            using var service = new ClassificationService(Globals.GetConnectionString());

            var collection = service.Get(new StandardFilter());
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
            treeCategories.ClearNodes();
            if (_classificationId <= 0) return;

            using var service = new CategoryService(Globals.GetConnectionString());
            Categories = service.Get(new StandardFilter());

            if(Categories is not { Count: > 0 }) return;

            LoadCategoryNodes();

        }

        private void LoadCategoryNodes()
        {
            //Get all parents
            var parents = (from c in Categories
                    where c.ParentId == 0
                    select new Category
                    {
                        Id = c.Id, ParentId = c.ParentId, Name = c.Name, IsActive = c.IsActive, IsDeleted = c.IsDeleted
                    })
                .ToList();

            //Loop and add
            foreach (var parent in parents)
            {
                var node = new TreeNode(text: parent.Name)
                {
                    Tag = parent.Id
                };
                LoadCategoryNodes(node);

                treeCategories.Nodes.Add(node);
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
                        Tag = child.Id
                    };
                    parentNode.Nodes.Add(node);

                    LoadCategoryNodes(node);
                }
            }
        }

        private void LoadCategoryEditor()
        {
            

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
                lblHeading.Text = $@"Edit {SelectedCategory.Name} ({SelectedCategory.Id})";

            }

            LoadCategoryEditorParents();

            Application.DoEvents();
        }

        private void LoadCategoryEditorParents()
        {
            cmbParents.Visible = chkParent.Checked = false;

            using var service = new CategoryService(Globals.GetConnectionString());
            var collection = service.Get(new StandardFilter { ParentId = 0 });
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

        }


        #endregion

        #region Control Event Procedures

        #region Filter

        private void cmbClassifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategoryNodes();
            SelectedCategory = new Category();
            LoadCategoryEditor();
            Application.DoEvents();
        }

        #endregion

        #region Editor

        private void chkParent_CheckedChanged(object sender, EventArgs e)
        {
            cmbParents.Visible = chkParent.Checked;
            Application.DoEvents();
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
                SelectedCategory.ParentId = chkParent.Checked ? (cmbClassifications.SelectedItem as Category)?.Id : 0;
                SelectedCategory.Name = txtName.Text.Trim();
                SelectedCategory.Description = txtDescription.Text.Trim();
                SelectedCategory.IsActive = chkActive.Checked;
                SelectedCategory.IsDeleted = false;

                //Save
                using var service = new CategoryService(Globals.GetConnectionString());
                if (SelectedCategory.Id <= 0)
                    service.Create(SelectedCategory);
                else
                    service.Update(SelectedCategory);

                //Reload & reset values
                LoadCategories();
                SelectedCategory = new Category();
                LoadCategoryEditor();

                //Message
                MessageBox.Show(@"Database has been updated and screen reloaded.", @"Save success",
                    MessageBoxButtons.OK);
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

        #endregion


        #endregion


    }
}