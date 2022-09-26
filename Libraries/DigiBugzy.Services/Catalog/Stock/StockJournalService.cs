

using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Core.ViewModels.Catalog;
using DigiBugzy.Services.Catalog.Products;
using DigiBugzy.Services.ContactBase.BusinessEntities;

namespace DigiBugzy.Services.Catalog.Stock
{
    public class StockJournalService:BaseService, IStockJournalService
    {
        #region Ctor

        /// <inheritdoc />
        public StockJournalService(string connectionString) : base(connectionString)
        {
        }

        /// <inheritdoc />
        public StockJournal GetLastEntry(int productId)
        {
            return dbContext.StockJournals.Where(x => x.ProductId == productId).OrderByDescending(x => x.Id).FirstOrDefault() ?? new StockJournal();
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
                //join  part in parts on journal.ProjectSectionPartId equals part.Id  --> not working without project section & outerjoin battling
                
                select new StockJournalViewModel
                {
                    Id = journal.Id,
                    QuantityIn = journal.QuantityIn,
                    QuantityOnOrder = journal.QuantityOnOrder,
                    QuantityOut = journal.QuantityOut,
                    QuantityReserved = journal.QuantityReserved,
                    TotalValue = journal.TotalValue,
                    TotalAvailable = journal.TotalInStock - journal.QuantityReserved,
                    ProductId = journal.ProductId,
                    ProductName = product.Name,
                    EntryDate = journal.EntryDate,
                    TotalInStock = journal.TotalInStock,
                    Title = journal.Name
                };

            //Outerjoin workaround
            using var pservice = new Projects.ProjectSectionPartService(_connectionString);
            using var prodservice = new ProductService(_connectionString);
            using var bservice = new BusinessEntityService(_connectionString);

            foreach (var result in results)
            {
                //Project info
                if (!result.ProjectSectionPartId.HasValue) continue;
                var pentry = pservice.GetById(result.ProjectSectionPartId.Value);
                result.ProjectSectionPartName = pentry.Name;

                //Product Info
                if (!string.IsNullOrEmpty(result.ProductName)) continue;
                var prod = prodservice.GetById(result.ProductId);
                result.ProductName = prod.Name;

                //Supplier
                if (!result.SupplierId.HasValue) continue;
                var bentry = bservice.GetById(result.SupplierId.Value);
                result.SupplierName = bentry.Name;
            }

            return results.OrderByDescending(x => x.Id).ToList();

        }


        #endregion

        #region Commands
        
        /// <inheritdoc />
        public int Create(StockJournal entity)
        {
            //Get last entity & update
            return Create(entity, GetLastEntry(entity.ProductId));
        }

        /// <inheritdoc />
        public int Create(StockJournal entity, StockJournal lastEntry)
        {
            entity.CreatedOn = DateTime.Now;
            //Perform calculations
            entity.TotalInStock = lastEntry.TotalInStock + entity.QuantityIn - entity.QuantityOut;
            entity.TotalValue = lastEntry.TotalValue + (entity.QuantityIn - entity.QuantityOut) * entity.Price;

            //Add to database
            dbContext.StockJournals.Add(entity);
            dbContext.SaveChanges();

            //Update product stock information
            var pservice = new ProductService(_connectionString);
            pservice.UpdateStockInfo(
                productId: entity.ProductId,
                totalValue: entity.TotalValue,
                totalInStock: entity.TotalInStock,
                qtyOnOrder: lastEntry.QuantityOnOrder + entity.QuantityOnOrder,
                qtyReserved: lastEntry.QuantityReserved + entity.QuantityReserved
            );

            return entity.Id;
        }

        /// <inheritdoc />
        public void ReverseEntry(int id)
        {
            var currentEntry = GetById(id);
            var newEntry = new StockJournal
            {
                ProductId = currentEntry.ProductId,
                QuantityIn = currentEntry.QuantityIn,
                QuantityOut = currentEntry.QuantityOut,
                QuantityReserved = currentEntry.QuantityReserved,
                Name = $"Reversal - {currentEntry.Name}",
                Description = $"Reversal - {currentEntry.Description} Journal No. {currentEntry.Id} on {currentEntry.CreatedOn}",
                DigiAdminId = currentEntry.DigiAdminId,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                IsReversed = true,
            };
            Create(newEntry);
        }



        /// <inheritdoc />
        public bool CanReverseJournal(int id)
        {
            var currentEntry = GetById(id);
            if (currentEntry.IsReversed) return false;
            
            var lastEntry = GetLastEntry(currentEntry.ProductId);
            return !(currentEntry.TotalInStock - currentEntry.TotalInStock < 0);
        }

        

        #endregion

        
    }
}
