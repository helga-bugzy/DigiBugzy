

namespace DigiBugzy.Core.ViewModels.Catalog
{
    /// <summary>
    /// View model for stock journal grid entries
    /// </summary>
    public class StockJournalViewModel
    {
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Related product primary key
        /// </summary>
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        /// <summary>
        /// If applicable, related project section part id
        /// </summary>
        public int? ProjectSectionPartId { get; set; }

        public string ProjectSectionPartName { get; set; }

        public int? SupplierId { get; set; }

        public string SupplierName { get; set; }

        /// <summary>
        /// Transaction/Entry Quantity - when stock is added
        /// </summary>
        public double QuantityIn { get; set; }

        /// <summary>
        /// When  stock is taken out i.e. for a project part
        /// </summary>
        public double QuantityOut { get; set; }

        /// <summary>
        /// Total physical in stock
        /// </summary>
        public double TotalInStock { get; set; }

        /// <summary>
        /// When reserving for a project this project part in planning but not executed yet
        /// </summary>
        public double QuantityReserved { get; set; }

        /// <summary>
        /// When stock is on order but not received yet
        /// </summary>
        public double QuantityOnOrder { get; set; }

        /// <summary>
        /// Total physical in stock minus quantity reserviced (in - out - reserved = available)
        /// </summary>
        public double TotalAvailable { get; set; }

        public double TotalValue { get; set; }
    }
}
