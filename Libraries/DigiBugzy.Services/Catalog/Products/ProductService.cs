

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


            if (!loadProductComplete) return query.ToList();


            //ProductComplete
            var collection = query.ToList();

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

        public void Delete(int id, bool hardDelete = false)
        {
            if (hardDelete)
            {
                var entity = GetById(id);
                if (entity != null || entity.Id > 0)
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
        }


        public void Update(Product entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name,
            };

            //TODO check for duplicate


            dbContext.Products.Update(entity);
        }

        #endregion
        

        #endregion

        #region Helper Methods

        private Product GetProductComplete(Product product)
        {
            using var productCategoryService = new ProductCategoryService(_connectionString);
            product.Categories.AddRange(productCategoryService.GetMappingViewModels(product.Id));

            using var productCustomFieldService = new ProductCustomFieldService(_connectionString);
            product.CustomFields.AddRange(productCustomFieldService.GetMappingViewModels(product.Id));

            return product;

        }

        

        

        #endregion


    }
}
