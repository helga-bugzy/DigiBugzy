

namespace DigiBugzy.Core.Domain.Products
{
    [Table(name: nameof(Product), Schema = DatabaseConstants.Schemas.Catalog)]
    public class Product: BaseAdministrationEntity
    {
        public byte[] ProductImage { get; set; }

        #region Product Complete Sub List

        public List<MappingViewModel> Categories { get; set; } = new();

        public List<MappingViewModel> CustomFields { get; set; } = new();

        #endregion
    }
}
