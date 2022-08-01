

namespace DigiBugzy.Core.Domain.Products
{
    [Table(name: nameof(ProductCustomField), Schema = DatabaseConstants.Schemas.Catalog)]
    public class ProductCustomField: BaseEntity
    {
        public int ProductId { get; set; }

        public int CustomFieldId { get; set; }

        public string Value { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(CustomFieldId))]
        public CustomField CustomField { get; set; }



    }
}
