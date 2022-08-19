

namespace DigiBugzy.Services.Catalog.Stock
{
    public class StockJournalService:BaseService, IStockJournalService
    {
        #region Ctor

        /// <inheritdoc />
        public StockJournalService(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Requests

        /// <inheritdoc />
        public StockJournal GetById(int id) => dbContext.StockJournals.FirstOrDefault(sj => sj.Id == id);

        /// <inheritdoc />
        public List<StockJournal> GetStockJournalViewModel(StockJournalSelectOptions options)
        {
            //var query = dbContext.StockJournals.AsQueryable<StockJournal>().Where(x => x.ProductId == options.ProductId);
            //if(options.SupplierId > 0)
            //{
            //    query = query.Where(x => x.SupplierId == options.SupplierId);
            //}

            //if (options.ProjectSectionPartId > 0)
            //{
            //    query = query.Where(x => x.ProjectSectionPartId == options.ProjectSectionPartId);
            //}

            //return query.Select(StockJournal).ToList();

            return new List<StockJournal>();
        }


        #endregion

        #region Commands
        
        /// <inheritdoc />
        public int Create(StockJournal entity)
        {
            //Get last entity
            var lastEntry = dbContext.StockJournals.Where(x => x.ProductId == entity.ProductId).OrderByDescending(x => x.Id).FirstOrDefault() ?? new StockJournal();
            
            //Perform calculations
            entity.TotalInStock = lastEntry.TotalInStock + entity.QuantityIn - entity.QuantityOut;
            entity.TotalValue = lastEntry.TotalValue + (entity.QuantityIn - entity.QuantityOut) * entity.Price;
            

            //Add to database
            dbContext.StockJournals.Add(entity);
            dbContext.SaveChanges();

            return entity.Id;
        }

        #endregion

        
    }
}
