

using DigiBugzy.Core.ViewModels.Catalog;

namespace DigiBugzy.Services.Catalog.Stock
{
    public interface  IStockJournalService
    {
        #region Requests

        /// <summary>
        /// Retrieves product on hand of it's primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StockJournal GetById(int id);

        /// <summary>
        /// Gets the last journal entry posted for the product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Last journal entry else new if not found</returns>
        public StockJournal GetLastEntry(int productId);

        public List<StockJournalViewModel> GetStockJournalViewModel(StockJournalSelectOptions options);

        #endregion


        #region Commands

        /// <summary>
        /// Creates a new product in the database
        /// NOTE: Stock item can never delete or update, always contra entry
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(StockJournal entity);

        /// <summary>
        /// Creates a new product in the database
        /// NOTE: Stock item can never delete or update, always contra entry
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lastEntry">Last joutnal entry for the said product</param>
        /// <returns></returns>
        public int Create(StockJournal entity, StockJournal lastEntry);

        /// <summary>
        /// Reverse an existing journal entry by creating new contra entry
        /// </summary>
        /// <param name="id"></param>
        public void ReverseEntry(int id);

        /// <summary>
        /// Validates stock levels so to indicate if reversal can take place
        /// </summary>
        /// <param name="id">Stock entry to be reversed</param>
        /// <returns></returns>
        public bool CanReverseJournal(int id);

        

        #endregion
    }
}
