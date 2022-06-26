namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models
{
    public class CustomFieldModel : BaseAdminsProperties
    {
        public int ClassificationId { get; set; }

        public int CustomFieldTypeId { get; set; }

        public Classification Classification { get; set; }

        public List<CustomFieldValueModel> CustomFields { get; set; } = new List<CustomFieldValueModel>();
    }
}
