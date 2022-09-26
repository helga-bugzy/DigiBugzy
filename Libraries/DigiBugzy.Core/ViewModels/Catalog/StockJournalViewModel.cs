

using System.ComponentModel;

namespace DigiBugzy.Core.ViewModels.Catalog
{
    /// <summary>
    /// View model for stock journal grid entries
    /// </summary>
    public class StockJournalViewModel
    {
        [DisplayName("#")]
        public int Id { get; set; }

        [DisplayName("Date")]
        public DateTime EntryDate { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Related product primary key
        /// </summary>
        public int ProductId { get; set; }

        [DisplayName("Product")]
        public string ProductName { get; set; }

        /// <summary>
        /// If applicable, related project section part id
        /// </summary>
        public int? ProjectSectionPartId { get; set; }

        [DisplayName("Proj. Part")]
        public string ProjectSectionPartName { get; set; }

        public int? SupplierId { get; set; }

        [DisplayName("Supplier")]
        public string SupplierName { get; set; }

        /// <summary>
        /// Transaction/Entry Quantity - when stock is added
        /// </summary>
        [DisplayName("Qty In")]
        public double QuantityIn { get; set; }

        /// <summary>
        /// When  stock is taken out i.e. for a project part
        /// </summary>
        [DisplayName("Qty Out")]
        public double QuantityOut { get; set; }

        /// <summary>
        /// Total physical in stock
        /// </summary>
        [DisplayName("Qty Out")]
        public double TotalInStock { get; set; }

        /// <summary>
        /// When reserving for a project this project part in planning but not executed yet
        /// </summary>
        [DisplayName("Qty Reserved")]
        public double QuantityReserved { get; set; }

        /// <summary>
        /// When stock is on order but not received yet
        /// </summary>
        [DisplayName("Qty On Order")]
        public double QuantityOnOrder { get; set; }

        /// <summary>
        /// Total physical in stock minus quantity reserviced (in - out - reserved = available)
        /// </summary>
        [DisplayName("Tot. Available")]
        public double TotalAvailable { get; set; }

        [DisplayName("Tot. Value")]
        public double TotalValue { get; set; }

    }
}
