
namespace DigiBugzy.Core.Domain.Finance.Assets
{
    [Table(name:nameof(Asset), Schema = DatabaseConstants.Schemas.Finance)]
    public class Asset: BaseAdministrationEntity
    {
        public int AssetTypeId { get; set; }

        public decimal PurchaseValue { get; set; }

        [ForeignKey(nameof(AssetTypeId))]
        public AssetType AssetType { get; set; }


    }
}
