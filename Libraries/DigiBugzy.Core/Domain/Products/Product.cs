

namespace DigiBugzy.Core.Domain.Products
{
    [Table(name: nameof(Product), Schema = DatabaseConstants.Schemas.Catalog)]
    public class Product: BaseAdministrationEntity
    {
        public byte[] ProductImage { get; set; }
    }
}
