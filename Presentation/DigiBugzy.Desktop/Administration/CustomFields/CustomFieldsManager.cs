using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DigiBugzy.Core.Domain.Administration.CustomFields;
using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Services.SampleData;

namespace DigiBugzy.Desktop.Administration.CustomFields
{
    public partial class CustomFieldsManager : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private int _classificationId;

        private readonly int _loadingClassificationId;

        private readonly bool _isLoading;

        private bool _isDragging;

        public Category SelectedCategory { get; set; }

        private List<MappingViewModel> _categories;

        private List<CustomField> CustomFields { get; set; } = new();

        private CustomField SelectedCustomField { get; set; } = new();

        private CustomFieldListOption SelectedListOption { get; set; } = new();

        #endregion

        #region Ctor

        public CustomFieldsManager(int classificationId = 0)
        {
            _categories = new List<MappingViewModel>();
            _classificationId = classificationId;
            _loadingClassificationId = classificationId;
            _isLoading = true;

            InitializeComponent();

            ApplySettings();

            LoadClassifications();
            LoadCustomFields();
            LoadCustomFieldEditor();

            _isLoading = false;
        }

        private void ApplySettings()
        {
            btnSampleDataDelete.Visible = btnSampleData.Visible =
                Globals.ConnectionEnvironment == ConnectionEnvironment.Development;
        }

        #endregion

        #region Public Methods



        #endregion

        #region Helper Methods



        private void ApplyFilter()
        {
            _classificationId = cmbClassifications.SelectedIndex < 0
                ? 0
                : (cmbClassifications.SelectedItem as Classification)!.Id;

            //Reload data
            LoadCustomFields();
            SelectedCustomField = new CustomField();
            LoadCustomFieldEditor();
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
                  
                    if (_isLoading)
                    {
                        if (item is not Classification classification || classification.Id != _loadingClassificationId) continue;
                        cmbClassifications.SelectedItem = item;
                        LoadCustomFields();
                        break;
                    }
                    else
                    {
                        if (item is not Classification classification || classification.Id != _classificationId) continue;
                        cmbClassifications.SelectedItem = item;
                        LoadCustomFields();
                        break;
                    }
                }
            }
            else
            {
                cmbClassifications.SelectedIndex = -1;
            }

            Application.DoEvents();
        }

        private void LoadCustomFieldTypes()
        {
            cmbTypes.DataSource = null;
            cmbTypes.Items.Clear();
            cmbTypes.DisplayMember = "Name";
            using var service = new CustomFieldTypeService(Globals.GetConnectionString());
            var collection = service.Get(new StandardFilter { DigiAdminId = Globals.DigiAdministration.Id });

            cmbTypes.DataSource = collection;
            cmbTypes.DisplayMember = "Name";
            cmbTypes.ValueMember = "Id";

            cmbTypes.SelectedIndex = -1;

            if (SelectedCustomField.Id > 0)
            {
                using var tService = new CustomFieldTypeService(Globals.GetConnectionString());
               

                var index = 0;

                foreach (var item in cmbTypes.Items)
                {
                    
                    var i = item as CustomFieldType;
                    if (i!.Id == SelectedCustomField.CustomFieldTypeId)
                    {
                        cmbTypes.SelectedIndex = index;
                    }

                    index++;
                }
            }

            Application.DoEvents();
        }

        private void LoadCustomFields()
        {
            grdOptions.Visible = false;
            twCustomFields.Nodes.Clear();

            if (_classificationId <= 0)
            {
                twCustomFields.Enabled = false;
                Application.DoEvents();
                return;
            }

            twCustomFields.Enabled = true;


            if (_classificationId <= 0) return;

            using var service = new CustomFieldService(Globals.GetConnectionString());
            CustomFields = service.Get(new StandardFilter
            {
                ClassificationId = _classificationId,
                DigiAdminId = Globals.DigiAdministration.Id,
                IncludeDeleted = chkIncludeDeleted.Checked,
                IncludeInActive = chkFilterInactive.Checked
            });

            if (CustomFields.Count <= 0) return;

            foreach (var item in CustomFields)
            {
                var node = new TreeNode(text: item.Name)
                {
                    Tag = item.Id,
                    NodeFont = CreateFont(item.IsDeleted, item.IsActive),
                    Text = item.Name
                };

                twCustomFields.Nodes.Add(node);
            }

            LoadCustomFieldEditor();
        }
        
        private void LoadCustomFieldEditor()
        {
            LoadCustomFieldTypes();
            LoadCategoriesTree();

            btnRestore.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnAddNew.Enabled = false;

            if (_classificationId <= 0)
            {
                Application.DoEvents();
                return;
            }
            
            if (SelectedCustomField.Id <= 0)
            {
                txtDescription.Text = txtName.Text = string.Empty;
                chkActive.Checked = true;
                lblHeading.Text = @"New CustomField";
                grdOptions.Visible = false;
                

            }
            else
            {
                txtName.Text = SelectedCustomField.Name;
                txtDescription.Text = SelectedCustomField.Description;
                chkActive.Checked = true;
                lblHeading.Text = $@"Edit {SelectedCustomField.Name} (ID: {SelectedCustomField.Id})";

                grdOptions.Visible = SelectedCustomField.CustomFieldTypeId ==7;
            }

            if (SelectedCustomField.Id > 0)
            {
                btnRestore.Enabled = SelectedCustomField.IsDeleted;
                btnDelete.Enabled = !SelectedCustomField.IsDeleted;
                btnSave.Enabled = true;
            }
            
            btnAddNew.Enabled = _classificationId > 0;

            LoadCustomFieldListOptions();


            Application.DoEvents();
        }

        private void LoadCustomFieldListOptions()
        {

            
            grdOptions.Columns.Clear();

            LoadCustomFieldListOptionsEditor();

            if (SelectedCustomField.Id > 0 &&
                SelectedCustomField.CustomFieldTypeId != (int)CustomFieldTypeEnumeration.ListType) return;

            using var service = new CustomFieldTypeService(Globals.GetConnectionString());
            var collection = service.GetListOptions(SelectedCustomField.Id, new StandardFilter());
            grdOptions.DataSource = collection;
            

            grdOptions.AllowUserToAddRows = true;
            grdOptions.Columns[0].Visible = false;
            grdOptions.Columns[1].HeaderText = @"Option Name";
            grdOptions.Columns[2].Visible = false;
            grdOptions.Columns[3].Visible = false;
            grdOptions.Columns[4].Visible = false;
            grdOptions.Columns[5].Visible = false;
            grdOptions.Columns[6].Visible = false;
            grdOptions.Columns[7].Visible = false;
            grdOptions.Columns[8].Visible = false;    //digiadminid

        }

        private void LoadCustomFieldListOptionsEditor()
        {
            btnOptionRestore.Enabled = false;
            btnOptionDelete.Enabled = false;
            btnOptionSave.Enabled = false;
            btnOptionNew.Enabled = false;

            if (_classificationId <= 0)
            {
                SelectedListOption = new CustomFieldListOption();
                return;
            }

            if (SelectedListOption.Id <= 0)
            {
                txtOptionName.Text = string.Empty;
                chkOptionActive.Checked = true;
                btnOptionRestore.Enabled  = false;
            }
            else
            {
                txtOptionName.Text = SelectedListOption.Value;
                chkOptionActive.Checked = SelectedListOption.IsActive;
                
            }

            if (SelectedListOption.Id > 0)
            {
                btnOptionRestore.Enabled = SelectedListOption.IsDeleted;
                btnOptionDelete.Enabled = !SelectedListOption.IsDeleted;
                btnOptionSave.Enabled = true;
            }

            btnOptionNew.Enabled = SelectedCustomField.Id > 0 && SelectedCustomField.CustomFieldTypeId == (int)CustomFieldTypeEnumeration.ListType;

            Application.DoEvents();
            
        }

        private void LoadCategoriesTree()
        {
            var customFieldService = new CustomFieldService(Globals.GetConnectionString());
            _categories = customFieldService.GetCategoryMappings(SelectedCustomField.Id, _classificationId);
            var parents = _categories.Where(m => m.ParentId is null).OrderBy(m => m.Name);
            foreach (var parent in parents)
            {
                var node = new TreeNode(text: parent.Name)
                {
                    Tag = parent.EntityMappedToId,
                    NodeFont = CreateFont(parent.IsDeleted, parent.IsActive)
                };

                LoadCategoryNodes(node, parent.EntityMappedToId);

                node.Text = $@"{parent.Name} ({node.Nodes.Count} subs)";

                if (node.Nodes.Count > 0)
                {
                    node.ImageIndex = 0;
                }

                twCategories.Nodes.Add(node);

            }

        }

        private void LoadCategoryNodes(TreeNode? parentNode, int parentId)
        {
            if (parentNode == null) return;
            var children = _categories
                .Where(c => c.ParentId == parentId)
                .OrderBy(c => c.Name)
                .ToList();

            if (children.Count <= 0) return;

            foreach (var child in children)
            {
                var node = new TreeNode(text: child.Name)
                {
                    Tag = child.Id,
                    NodeFont = CreateFont(child.IsDeleted, child.IsActive)
                };

                parentNode.Nodes.Add(node);

                LoadCategoryNodes(node, child.Id);
            }
        }


        private Font CreateFont(bool isDeleted, bool isActive)
        {
            var font = new Font(twCustomFields.Font.FontFamily, twCustomFields.Font.Size);
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


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SelectedCustomField = new CustomField();
            LoadCustomFieldEditor();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validations
                if (cmbTypes.SelectedIndex < 0)
                {
                    MessageBox.Show(@"Please select a valid type.",
                        @"Validation Error", MessageBoxButtons.OK);
                    return;
                }

                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show(@"Please enter a name for the CustomField", @"Validation Error",
                        MessageBoxButtons.OK);
                    return;
                }


                //Set values
                if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    txtDescription.Text = txtName.Text;
                }

                SelectedCustomField.ClassificationId = _classificationId;
                SelectedCustomField.CustomFieldTypeId =
                    int.Parse((cmbTypes.SelectedItem as CustomFieldType)!.Id.ToString());
                SelectedCustomField.Name = txtName.Text.Trim();
                SelectedCustomField.Description = txtDescription.Text.Trim();
                SelectedCustomField.IsActive = chkActive.Checked;
                SelectedCustomField.IsDeleted = false;

                //Save
                using var service = new CustomFieldService(Globals.GetConnectionString());
                if (SelectedCustomField.Id <= 0)
                {
                    SelectedCustomField.CreatedOn = DateTime.Now;
                    SelectedCustomField.DigiAdminId = Globals.DigiAdministration.Id;
                    service.Create(SelectedCustomField);
                }
                else
                    service.Update(SelectedCustomField);

                //Reload & reset values
                LoadCustomFields();
                SelectedCustomField = new CustomField();
                LoadCustomFieldEditor();

            }
            catch (Exception exception)
            {
                MessageBox.Show(@$"Error saving CustomField information: {exception.Message}");
            }
            finally
            {
                Application.DoEvents();
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedCustomField.Id <= 0) return;
            using var service = new CustomFieldService(Globals.GetConnectionString());
            service.Delete(SelectedCustomField.Id, true);

            LoadCustomFields();
            SelectedCustomField = new CustomField();
            LoadCustomFieldEditor();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (SelectedCustomField.Id <= 0) return;
            SelectedCustomField.IsDeleted = false;
            SelectedCustomField.IsActive = true;
            using var service = new CustomFieldService(Globals.GetConnectionString());
            service.Update(SelectedCustomField);

            LoadCustomFields();
            LoadCustomFieldEditor();
        }
        
        #endregion

        #region Treeview

        private void twCustomFields_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
         
            using var service = new CustomFieldService(Globals.GetConnectionString());
            SelectedCustomField = service.GetById(int.Parse(e.Node.Tag.ToString()!));
            SelectedListOption = new CustomFieldListOption();
            LoadCustomFieldEditor();
            Application.DoEvents();
        }

        #region Categories Treeview

        private void twCategories_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_isDragging) return;
            using var service = new CategoryService(Globals.GetConnectionString());
            SelectedCategory = service.GetById(int.Parse(e.Node.Tag.ToString()!));

            //TODO LoadCategoryEditor();

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
                }

                // Expand the node at the location   
                // to show the dropped node.  
                targetNode.Expand();

                _isDragging = false;
            }

            Application.DoEvents();
        }

        private void twCategories_AfterCheck(object sender, TreeViewEventArgs e)
        {
            using var service = new CategoryService(Globals.GetConnectionString());
            service.HandleCustomFieldMapping(SelectedCategory.Id, int.Parse(e.Node!.Tag.ToString()!), e.Node.Checked, chkCustomFieldsToChild.Checked);
        }

        #endregion


        #endregion

        #region Options

        private void grdOptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedCustomField.Id <= 0) return;
            var id = int.Parse(grdOptions.Rows[e.RowIndex].Cells["Id"].Value.ToString()!);

            using var service = new CustomFieldTypeService(Globals.GetConnectionString());
            SelectedListOption = service.GetListOptionById(id);

            LoadCustomFieldListOptionsEditor();
            Application.DoEvents();
        }

        private void grdOptions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOptionSave_Click(object sender, EventArgs e)
        {
            if (SelectedCustomField.Id <= 0) return;

            SelectedListOption.IsActive = chkActive.Checked;
            SelectedListOption.IsDeleted = false;
            SelectedListOption.Value = txtOptionName.Text.Trim();
            SelectedListOption.DigiAdminId = Globals.DigiAdministration.Id;
            SelectedListOption.CustomFieldId = SelectedCustomField.Id;

            using var service = new CustomFieldTypeService(Globals.GetConnectionString());

            if (SelectedListOption.Id <= 0)
            {
                SelectedListOption.CreatedOn = DateTime.Now;
                service.AddListOption(SelectedListOption);
            }
            else
            {
                service.UpdateListOption(SelectedListOption);
            }



            LoadCustomFieldListOptions();
        }

        private void bnOptionNew_Click(object sender, EventArgs e)
        {
            if (SelectedCustomField.Id <= 0) return;

            SelectedListOption = new CustomFieldListOption();
            LoadCustomFieldListOptionsEditor();
            Application.DoEvents();

        }

        private void btnOptionRestore_Click(object sender, EventArgs e)
        {
            if (SelectedCustomField.Id <= 0 || SelectedListOption.Id <= 0) return;

            SelectedListOption.IsActive = true;
            SelectedListOption.IsDeleted = false;

            using var service = new CustomFieldTypeService(Globals.GetConnectionString());
            service.UpdateListOption(SelectedListOption);

            LoadCustomFieldListOptions();

        }

        private void btnOptionDelete_Click(object sender, EventArgs e)
        {
            if (SelectedCustomField.Id <= 0 || SelectedListOption.Id <= 0) return;

            SelectedListOption.IsActive = false;
            SelectedListOption.IsDeleted = true;

            using var service = new CustomFieldTypeService(Globals.GetConnectionString());
            service.UpdateListOption(SelectedListOption);

            LoadCustomFieldListOptions();
        }


        #endregion

        #region Sample Data

        private void btnSampleData_Click(object sender, EventArgs e)
        {
            using var service = new SampleDataService(
                connectionString: Globals.GetConnectionString(),
                sampleDataType: SampleDataTypeEnum.CustomFields, 
                classificationId: _classificationId,
                digiAdminId: Globals.DigiAdministration.Id);
            service.CreateSampleData();

            LoadCustomFields();
            Application.DoEvents();
        }

        private void btnSampleDataDelete_Click(object sender, EventArgs e)
        {
            using var service = new SampleDataService(
                connectionString: Globals.GetConnectionString(),
                sampleDataType: SampleDataTypeEnum.CustomFields,
                classificationId: _classificationId,
                digiAdminId: Globals.DigiAdministration.Id);
            service.DeleteSampleData();
            LoadCustomFields();
        }


        #endregion

        #endregion

        #region Helper Methods


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



        #endregion

        
    }
}