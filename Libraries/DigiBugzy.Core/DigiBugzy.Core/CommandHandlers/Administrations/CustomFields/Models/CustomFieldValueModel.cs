namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models
{
    public class CustomFieldValueModel : BaseAdminsProperties
    {
        public int CustomFieldId { get; set; }


        public CustomFieldModel CustomField { get; set; } = new();
    }
}
