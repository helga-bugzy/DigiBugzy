#nullable enable
using DigiBugzy.Core.Domain.BusinessEntities;
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
        public double QuantityIn { get; set; } = 0;

        /// <summary>
        /// When  stock is taken out i.e. for a project part
        /// </summary>
        public double QuantityOut { get; set; } = 0;

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

        public double Price { get; set; } = 0;

        /// <summary>
        /// Total in (total price + (price * qty (in or out)))
        /// </summary>
        public double TotalValue { get; set; } = 0;



        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public BusinessEntity? Supplier { get; set; }

        [ForeignKey(nameof(ProjectSectionPartId))]
        public ProjectSectionPart? ProjectSectionPart { get; set; }
    }
}
