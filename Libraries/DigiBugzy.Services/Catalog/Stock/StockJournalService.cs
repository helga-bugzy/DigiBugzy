
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
        public void Delete(int id, bool hardDelete)
        {
            Delete(GetById(id), hardDelete);
        }

        /// <inheritdoc />
        public void Delete(StockJournal entity, bool hardDelete)
        {
            if (hardDelete)
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                Update(entity);
            }
            else
            {
                dbContext.StockJournals.Remove(entity);
                dbContext.SaveChanges();
            }

        }

        /// <inheritdoc />
        public void Delete(List<StockJournal> entities, bool hardDelete)
        {
            foreach(var entity in entities)
            {
                Delete(entity, hardDelete);
            }
        }

        /// <inheritdoc />
        public void Update(StockJournal entity) 
        {
            dbContext.StockJournals.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public int Create(StockJournal entity)
        {
            dbContext.StockJournals.Add(entity);
            dbContext.SaveChanges();

            return entity.Id;
        }

        #endregion

        
    }
}
