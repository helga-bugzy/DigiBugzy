

using System.Runtime.Serialization;

namespace DigiBugzy.Core.Domain.Products
{
    [Table(name: nameof(Product), Schema = DatabaseConstants.Schemas.Catalog)]
    public class Product: BaseAdministrationEntity
    {
        public byte[] ProductImage { get; set; }

        #region Product Complete Sub List

       
        public List<ProductCategory> Categories { get; set; } = new();

        public List<ProductCustomField> CustomFields { get; set; } = new();

        #endregion
    }
}
