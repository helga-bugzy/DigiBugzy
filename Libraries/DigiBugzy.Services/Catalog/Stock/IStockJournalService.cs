

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


        public List<StockJournal> GetStockJournalViewModel(StockJournalSelectOptions options);

        #endregion


        #region Commands

        /// <summary>
        /// Creates a new product in the database
        /// NOTE: Stock item can never delete or update, always contra entry
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(StockJournal entity);

        #endregion
    }
}
