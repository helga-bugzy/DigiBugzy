using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Core.Domain.Products
{
    [Table(name: nameof(StockJournal), Schema = DatabaseConstants.Schemas.Catalog)]
    public class StockJournal : BaseAdministrationEntity
    {
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Related product primary key
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// If applicable, related project section part id
        /// </summary>
        public int? ProjectSectionPartId { get; set; }

        public int? SupplierId { get; set; }

        /// <summary>
        /// Transaction/Entry Quantity - when stock is added
        /// </summary>
        public decimal QuantityIn { get; set; } = 0;

        /// <summary>
        /// When  stock is taken out i.e. for a project part
        /// </summary>
        public decimal QuantityOut { get; set; } = 0;

        /// <summary>
        /// Total physical in stock
        /// </summary>
        public decimal TotalInStock { get; set; } = 0;

        /// <summary>
        /// When reserving for a project this project part in planning but not executed yet
        /// </summary>
        public decimal QuantityReserved { get; set; } = 0;

        /// <summary>
        /// When stock is on order but not received yet
        /// </summary>
        public decimal QuantityOnOrder { get; set; } = 0;

        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Total in (total price + (price * qty (in or out)))
        /// </summary>
        public decimal TotalValue { get; set; } = 0;



        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(ProjectSectionPartId))]
        public ProjectSectionPart ProjectSectionPart { get; set; } = new();
    }
}
