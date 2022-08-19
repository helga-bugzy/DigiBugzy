

namespace DigiBugzy.Services.Catalog.Stock
{
    public class StockJournalSelectOptions
    {
        public int ProductId { get; set; }

        public int ProjectId { get; set; } = 0;

        public int ProjectSectionId { get; set; } = 0;

        public int ProjectSectionPartId { get; set; } = 0;

        public int SupplierId { get; set; } = 0;

        public StockJournalSelectOptions(int productId)
        {
            ProductId = productId;        
        }
    }
}
