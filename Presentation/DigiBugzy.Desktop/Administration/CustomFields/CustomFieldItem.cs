using DevExpress.XtraEditors;
using DigiBugzy.Core.Domain.Administration.CustomFields;
using DigiBugzy.Core.Domain.Products;
using DigiBugzy.Core.Domain.xBase;

namespace DigiBugzy.Desktop.Administration.CustomFields
{
    public partial class CustomFieldItem : XtraUserControl
    {
        public SampleDataTypeEnum MappingType { get; set; }
        
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

        public CustomFieldItem(MappingViewModel? customField = null, SampleDataTypeEnum mappingType = default)
        {
            InitializeComponent();
            CustomField = customField;
            txtValue.Visible = cmbValue.Visible = rbFalse.Visible = rbTrue.Visible = btnRefresh.Visible = false;
            MappingType = mappingType;

            if (customField != null) LoadCustomField();
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
            cmbValue.DisplayMember = "Value";
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
                    if (cmbValue.SelectedIndex >= 0)
                    {
                        var option = (CustomFieldListOption)cmbValue.SelectedItem;
                        CustomField.CustomFieldValue = option.Id.ToString();
                    }
                    break;
                case (int)CustomFieldTypeEnumeration.Boolean:
                    CustomField.CustomFieldValue = rbFalse.Checked ? "0" : "1";
                    break;
                default:
                    CustomField.CustomFieldValue = txtValue.Text;
                    break;
            }

            switch (MappingType)
            {
                case SampleDataTypeEnum.Products:
                    SaveProductMapping();
                    break;
            }

        }

        #endregion

        #region Saving

        private void SaveProductMapping()
        {
            if (CustomField == null) return;
            using var service = new ProductCustomFieldService(Globals.GetConnectionString());
            var entity = new ProductCustomField()
            {
                ProductId = CustomField.EntityMappedFromId,
                CustomFieldId = CustomField.EntityMappedToId,
                Value = CustomField.CustomFieldValue
            };
            service.Update(entity);
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
                    cmbValue.Visible = btnRefresh.Visible = true;
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
                    txtValue.Text = CustomField.CustomFieldValue;
                    break;
                default:
                    txtValue.Visible = true;
                    txtValue.Text = CustomField.CustomFieldValue;
                    break;

            }

        }
        

        #endregion

        #region Control Event Procedures

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOptionsListValues();
            Application.DoEvents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCustomField();
        }

        #endregion


    }

}