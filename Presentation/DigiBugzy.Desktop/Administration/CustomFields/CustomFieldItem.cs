using DevExpress.XtraEditors;
using DigiBugzy.Core.Domain.Administration.CustomFields;
using DigiBugzy.Core.Domain.xBase;

namespace DigiBugzy.Desktop.Administration.CustomFields
{
    public partial class CustomFieldItem : XtraUserControl
    {
        private MappingViewModel? _customFieldModel;

        public MappingViewModel? CustomField
        {
            get => _customFieldModel;
            set
            {
                _customFieldModel = value;
                LoadCustomField();
            }
        }

        public CustomFieldItem(MappingViewModel? customField = null)
        {
            InitializeComponent();
            CustomField = customField;
            txtValue.Visible = cmbValue.Visible = rbFalse.Visible = rbTrue.Visible = false;
            
        }

        #region Private Methods

        private void LoadCustomField()
        {
            
            HandleTypeControls();
            lblName.Text = CustomField?.Name;
        }

        private void LoadOptionsListValues()
        {
            cmbValue.Items.Clear();
            if(CustomField == null) return;

            var service = new CustomFieldListOptionService(Globals.GetConnectionString());
            var options = service.GetForCustomFieldId(CustomField.EntityMappedToId);
            cmbValue.DataSource = options;
            cmbValue.DisplayMember = "Name";
            cmbValue.ValueMember = "Id";

            if (CustomField.TypeId > 0)
            {
                foreach (var item in cmbValue.Items)
                {
                    if (item is not CustomFieldListOption option || option.Id != CustomField.TypeId) continue;
                    cmbValue.SelectedItem = item;
                    break;
                }
            }
            else
            {
                cmbValue.SelectedIndex = -1;
            }

        }

        public void SaveCustomField()
        {
            if (CustomField == null) return;
            switch (CustomField.TypeId)
            {
                case (int)CustomFieldTypeEnumeration.ListType:
                    break;
                case (int)CustomFieldTypeEnumeration.Boolean:
                    CustomField.CustomFieldValue = rbFalse.Checked ? "0" : "1";
                    break;
                default:
                    CustomField.CustomFieldValue = txtValue.Text;
                    break;
            }

        }

        #endregion

        #region Helper Methods

        private void HandleTypeControls()
        {
            
            txtValue.Visible = cmbValue.Visible = rbFalse.Visible = rbTrue.Visible = false;

            if (CustomField == null) return;
            switch (CustomField.TypeId)
            {
                case (int)CustomFieldTypeEnumeration.ListType:
                    cmbValue.Visible = true;
                    LoadOptionsListValues();

                    break;
                case (int)CustomFieldTypeEnumeration.Boolean:
                    rbFalse.Visible = rbTrue.Visible = true;
                    switch (CustomField.CustomFieldValue)
                    {
                        case "1":
                            rbTrue.Checked = true;
                            rbFalse.Checked = false;
                            break;
                        case "0":
                            rbTrue.Checked = false;
                            rbFalse.Checked = true;
                            break;
                    }

                    break;
                case (int)CustomFieldTypeEnumeration.Memo:
                    txtValue.Visible = true;

                    break;
                default:
                    txtValue.Visible = true;

                    break;

            }

        }





        #endregion

    }

}