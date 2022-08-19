

namespace DigiBugzy.Services.Catalog.Stock
{
    public class StockJournalSelectOptions
    {
        public int ProductId { get; set; }

        public int? ProjectId { get; set; }

        public int? ProjectSectionId { get; set; }

        public int? ProjectSectionPartId { get; set; }

        public int? SupplierId { get; set; } 

        public StockJournalSelectOptions(int productId)
        {
            ProductId = productId;        
        }
    }
}
