

namespace DigiBugzy.Core.Domain.Products
{
    [Table(name: nameof(Product), Schema = DatabaseConstants.Schemas.Catalog)]
    public abstract class Product: BaseAdministrationEntity
    {
    }
}
