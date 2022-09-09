

namespace DigiBugzy.Core.Domain.Products
{
    [Table(name: nameof(Product), Schema = DatabaseConstants.Schemas.Catalog)]
    public class Product: BaseAdministrationEntity
    {
        public byte[] ProductImage { get; set; }


        public int? ParentId { get; set; }

        /// <summary>
        /// Total physical in stock
        /// </summary>
        public double TotalInStock { get; set; } = 0;

        /// <summary>
        /// When reserving for a project this project part in planning but not executed yet
        /// </summary>
        public double QuantityReserved { get; set; } = 0;

        /// <summary>
        /// When stock is on order but not received yet
        /// </summary>
        public double QuantityOnOrder { get; set; } = 0;

        /// <summary>
        /// Total in (total price + (price * qty (in or out)))
        /// </summary>
        public double TotalValue { get; set; } = 0;


        #region Product Complete Subs

        [ForeignKey(nameof(ParentId))]
        public Product Parent { get; set; }


        public List<ProductCategory> Categories { get; set; } = new();

        public List<ProductCustomField> CustomFields { get; set; } = new();

        #endregion
    }
}
