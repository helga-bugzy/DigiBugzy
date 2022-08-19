
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
        /// Retrieves product on hand of it's primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<StockJournal> GetByProductId(int id);

        /// <summary>
        /// Retrieves product on hand of it's primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<StockJournal> GetBySupplierId(int id);


        public List<StockJournal> GetByProjectSectionPartId(int id);

        public List<StockJournal> GetByProjectSectionId(int id);

        public List<StockJournal> GetByProjectId(int id);

        /// <summary>
        /// Gets a list of products on hand of the filter values
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<StockJournal> Get(StandardFilter filter);


        #endregion


        #region Commands

        /// <summary>
        /// Deletes an existing product (soft/hard)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete);

        public void Delete(StockJournal entity, bool hardDelete);

        public void Delete(List<StockJournal> entities, bool hardDelete);



        /// <summary>
        /// Updates details of an existing product
        /// </summary>
        /// <param name="entity"></param>
        public void Update(StockJournal entity);

        /// <summary>
        /// Creates a new product in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(StockJournal entity);

        #endregion
    }
}
