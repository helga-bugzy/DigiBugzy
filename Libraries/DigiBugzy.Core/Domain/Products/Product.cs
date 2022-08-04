

namespace DigiBugzy.Core.Domain.Products
{
    [Table(name: nameof(Product), Schema = DatabaseConstants.Schemas.Catalog)]
    public class Product: BaseAdministrationEntity
    {
        public byte[] ProductImage { get; set; }


        public int? ParentId { get; set; }



        #region Product Complete Subs

        [ForeignKey(nameof(ParentId))]
        public Product Parent { get; set; }


        public List<ProductCategory> Categories { get; set; } = new();

        public List<ProductCustomField> CustomFields { get; set; } = new();

        #endregion
    }
}
