using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigiBugzy.Core.Domain.Administration.CustomFields;

namespace DigiBugzy.Desktop.Administration.CustomFields
{
    public partial class CustomFieldsManager : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private int _classificationId;

        private List<CustomField> CustomFields { get; set; } = new();

        private CustomField SelectedCustomField { get; set; } = new();

        private bool _isDragging { get; set; }


        #endregion

        #region Ctor

        public CustomFieldsManager(int classificationId = 0)
        {
            _classificationId = classificationId;
            InitializeComponent();

            LoadClassifications();
            LoadCustomFields();
            LoadCustomFieldEditor();
        }

        #endregion

        #region Public Methods



        #endregion

        #region Helper Methods

        private void ApplyFilter()
        {
            _classificationId = cmbClassifications.SelectedIndex < 0 ? 0 : (cmbClassifications.SelectedItem as Classification)!.Id;

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
                    if (item is not Classification classification || classification.Id != _classificationId) continue;
                    cmbClassifications.SelectedItem = item;
                    LoadCustomFields();
                    break;
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
            using var service = new CustomFieldTypeService(Globals.GetConnectionString());
            var collection = service.Get(new StandardFilter { DigiAdminId = Globals.DigiAdministration.Id });
            cmbTypes.DataSource = collection;
            cmbTypes.DisplayMember = "Name";
            cmbTypes.ValueMember = "Id";

            if (SelectedCustomField.Id <= 0)
            {
                cmbTypes.SelectedItem = -1;
            }
            else
            {
                var index = 0;
                foreach (var item in cmbTypes.Items)
                {
                    if (item is CustomFieldType x && x.Id == SelectedCustomField.Id)
                    {
                        cmbTypes.SelectedIndex = index;
                        break;
                    }

                    index++;
                }
            }
            

            Application.DoEvents();
        }

        private void LoadCustomFields()
        {
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

        }

      
        private void LoadCustomFieldEditor()
        {
            LoadCustomFieldTypes();

            if (_classificationId <= 0)
            {
                pnlEditor.Visible = false;
                btnRestore.Visible = false;
                Application.DoEvents();
                return;
            }

            pnlEditor.Visible = true;

            if (SelectedCustomField.Id <= 0)
            {
                txtDescription.Text = txtName.Text = string.Empty;
                chkActive.Checked = true;
                lblHeading.Text = @"New CustomField";

            }
            else
            {
                txtName.Text = SelectedCustomField.Name;
                txtDescription.Text = SelectedCustomField.Description;
                chkActive.Checked = true;
                lblHeading.Text = $@"Edit {SelectedCustomField.Name} (ID: {SelectedCustomField.Id})";

            }

            btnRestore.Visible = SelectedCustomField.IsDeleted;
            LoadCustomFieldListOptions();
            

            Application.DoEvents();
        }

        private void LoadCustomFieldListOptions()
        {
            grdOptions.Visible = true;

            if (SelectedCustomField.Id <= 0 ||
                SelectedCustomField.CustomFieldTypeId == (int)CustomFieldTypeEnumeration.ListType)
            {
                grdOptions.Visible = true;
                using var service = new CustomFieldTypeService(Globals.GetConnectionString());
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
                    MessageBox.Show(@"Please enter a name for the CustomField", @"Validation Error", MessageBoxButtons.OK);
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
            service.Delete(SelectedCustomField.Id);

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
            //SelectedCustomField = new CustomField();
            LoadCustomFieldEditor();
        }



        #endregion

        #region Treeview

        private void twCustomFields_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_isDragging) return;
            using var service = new CustomFieldService(Globals.GetConnectionString());
            SelectedCustomField = service.GetById(int.Parse(e.Node.Tag.ToString()!));

            LoadCustomFieldEditor();

            Application.DoEvents();

        }








        #endregion

        #endregion

        private void grdOptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("CellClick");
        }
    }
}