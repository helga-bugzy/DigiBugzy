




namespace DigiBugzy.Core.Domain.Administration.Categories
{
    [Table(name: nameof(CategoryCustomField), Schema=DatabaseConstants.Schemas.Admin)]
    public class CategoryCustomField: BaseEntity
    {
        [Required]
        public int CustomFieldId { get; set; }
        
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CustomFieldId))]
        public CustomField CustomField { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
