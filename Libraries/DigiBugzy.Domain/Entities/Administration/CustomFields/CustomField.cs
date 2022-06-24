
namespace DigiBugzy.Domain.Entities.Administration.CustomFields
{
    [Table(name: nameof(CustomField), Schema = DatabaseConstants.Schemas.Admin)]
    public abstract class CustomField: BaseAdministrationEntity
    {
        [Required]        
        public int CustomFieldTypeId { get; set; }

        [Required]
        public int ClassificationId { get; set; }


        [ForeignKey(nameof(CustomFieldTypeId))]
        public CustomFieldType CustomFieldType { get; set; }

        [ForeignKey(nameof(ClassificationId))]
        public Classification CustomFieldClassification { get; set; }
    }
}
