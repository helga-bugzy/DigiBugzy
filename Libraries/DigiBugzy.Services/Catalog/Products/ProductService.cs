

using Microsoft.EntityFrameworkCore;

namespace DigiBugzy.Services.Catalog.Products
{
    public class ProductService :BaseService, IProductService
    {
        #region Fields



        #endregion

        #region Ctor

        public ProductService(string connectionString) : base(connectionString)
        {

        }

        #endregion

        #region Methods

        #region Requests

        public List<Product> Get(StandardFilter filter, bool loadProductComplete = false)
        {
            var query = dbContext.Products.AsQueryable<Product>();

            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            

            if (filter.DigiAdminId.HasValue)
            {
                query = query.Where(x => x.DigiAdminId == filter.DigiAdminId);
            }


            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = filter.LikeSearch ? query.Where(x => x.Name.Contains(filter.Name)) : query.Where(x => x.Name.Equals(filter.Name));
            }

            if (!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == true);

            //When there is category mappings, include the category information
            query = query.Include(x => x.Categories)
                .ThenInclude(xx => xx.Category);


            if (!loadProductComplete) return query.ToList();

            //ProductComplete
            var collection = query.ToList();

            if (filter.CategoryId is > 0)
            {
                var categoryMappings = dbContext.ProductCategories.Where(pc => pc.CategoryId == filter.CategoryId);

                collection = (
                    from p in collection 
                    join cm in categoryMappings
                        on p.Id equals cm.ProductId
                              select p).ToList();

            }

            return collection.Select(GetProductComplete).ToList();

        }

        public Product GetById(int id, bool loadProductComplete = false)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (loadProductComplete)
            {
                product = GetProductComplete(product);
            }

            return product;
        }

        #endregion

        #region Commands

        public int Create(Product entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0) Update(entity);
            else
            {
                dbContext.Add(entity);
                dbContext.SaveChanges();

            }

            return entity.Id;

        }

        public void Delete(int id, bool hardDelete)
        {
            var entity = GetById(id);
            Delete(entity, hardDelete);
        }

        /// <inheritdoc />
        public void Delete(Product entity, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.Products.Remove(entity);
                dbContext.SaveChanges();
            }
            else
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                Update(entity);
            }
        }

        /// <inheritdoc />
        public void Delete(List<Product> entities, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.Products.RemoveRange(entities);
                dbContext.SaveChanges();
            }
            else
            {
                foreach (var entity in entities)
                {
                    Delete(entity, false);
                }
            }
        }


        public void Update(Product entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name,
            };

            //TODO check for duplicate

            
            dbContext.Products.Update(entity);
           // dbContext.Entry<Product>(entity).Collection(x => x.Categories).IsModified = false;
          //  dbContext.Entry<Product>(entity).Property(x => x.CustomFields).IsModified = false;
            dbContext.SaveChanges();
        }

        #endregion
        

        #endregion

        #region Helper Methods

        private Product GetProductComplete(Product product)
        {
            using var productCategoryService = new ProductCategoryService(_connectionString);
            product.Categories.AddRange(productCategoryService.GetByProductId(product.Id));

            using var productCustomFieldService = new ProductCustomFieldService(_connectionString);
            product.CustomFields.AddRange(productCustomFieldService.GetByProductId(product.Id));

            return product;

        }

        

        

        #endregion


    }
}
