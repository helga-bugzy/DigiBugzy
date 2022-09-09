

using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Core.ViewModels.Catalog;

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
        public List<StockJournalViewModel> GetStockJournalViewModel(StockJournalSelectOptions options)
        {

            var journals = dbContext.StockJournals.AsQueryable<StockJournal>().Where(x => x.ProductId == options.ProductId);

            if (options.SupplierId is > 0) journals = journals.Where(x => x.SupplierId == options.SupplierId);
            if (options.ProjectSectionPartId is > 0) journals.Where(x => x.ProjectSectionPartId == options.ProjectSectionPartId);


            //Products join (inner join)
            var products = dbContext.Products.AsQueryable<Product>();

            //Product section part (outer join)
            var parts = dbContext.ProjectSectionParts.AsQueryable<ProjectSectionPart>();

            var results =
                from journal in journals
                join product in products on journal.ProductId equals product.Id
                join part in parts on journal.ProjectSectionPartId equals part.Id
                
                select new StockJournalViewModel
                {
                    QuantityIn = journal.QuantityIn,
                    QuantityOnOrder = journal.QuantityOnOrder,
                    QuantityOut = journal.QuantityOut,
                    QuantityReserved = journal.QuantityReserved,
                    TotalValue = journal.TotalValue,
                    TotalAvailable = journal.TotalInStock - journal.QuantityReserved,
                    ProductId = journal.ProductId,
                    ProductName = product.Name,
                    EntryDate = journal.EntryDate,
                };

            return results.OrderByDescending(x => x.EntryDate).ToList();



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

            //Update product
            var product = dbContext.Products.FirstOrDefault(x => x.Id == entity.ProductId);
            if (product == null) return entity.Id;

            product.TotalValue = entity.TotalValue;
            product.TotalInStock = entity.TotalInStock;
            product.QuantityOnOrder = lastEntry.QuantityOnOrder + entity.QuantityOnOrder;
            product.QuantityReserved = lastEntry.QuantityReserved + entity.QuantityReserved;
            dbContext.Update(product);

            return entity.Id;
        }

        #endregion

        
    }
}
