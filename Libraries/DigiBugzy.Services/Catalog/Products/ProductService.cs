
using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Core.Domain.xBase.Interfaces;
using DigiBugzy.Services.Administration.Categories;
using DigiBugzy.Services.Administration.CustomFields;

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

        #region Mappings

        #region Categories

        /// <inheritdoc />
        public List<MappingViewModel> GetCategoryMappings(int productId, int classificationId)
        {
            using var cservice = new CategoryService(_connectionString);
            var categories = cservice.Get(new StandardFilter
            {
                ClassificationId = classificationId
            });

            using var mservice = new ProductCategoryService(_connectionString);
            var mappings = mservice.GetByProductId(productId);


            var results = (
                    from category in categories
                    let map = mappings.FirstOrDefault(m => m.CategoryId == category.Id)
                    where map != null
                    select new MappingViewModel
                    {
                        EntityMappedFromId = productId, 
                        EntityMappedToId = category.Id, 
                        IsMapped = map.Id > 0,
                        ParentId = category.ParentId
                    })
                .ToList();

            return results;
        }

        /// <inheritdoc />
        public void HandleCategoryMapping(int categoryId, int productId, bool isMapped)
        {
            var item = dbContext.ProductCategories
                .FirstOrDefault(x => x.CategoryId == categoryId && x.ProductId == productId);

            if (item == null || item is not {Id: > 0})
            {
                item = new ProductCategory()
                {
                    DigiAdminId = 1,
                    CategoryId = categoryId,
                    CreatedOn = DateTime.Now,
                    ProductId = productId,
                    IsDeleted = false,
                    IsActive = true,
                };
                dbContext.ProductCategories.Add(item);
                dbContext.SaveChanges();
            }
            else if(!isMapped)
            {
                dbContext.ProductCategories.Remove(item);
                dbContext.SaveChanges();
            }


        }

        #endregion

        #region Custom Fields

        /// <inheritdoc />
        public List<MappingViewModel> GetCustomFieldMappings(int categoryId, int classificationId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void HandleCustomFieldMapping(int categoryId, int customFieldId, bool isMapped)
        {
            throw new NotImplementedException();
        }

        #endregion

        

        #endregion



        #endregion

        #region Helper Methods

        private Product GetProductComplete(Product product)
        {
            
            product.Categories.AddRange(GetProductCategoriesViewModels(product));
            product.CustomFields.AddRange(GetProductCustomFieldModels(product));

            return product;

        }

        /// <summary>
        /// Gets all category mappings as view model for the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private IEnumerable<MappingViewModel> GetProductCategoriesViewModels(IBaseEntity product)
        {
            using var service = new ProductCategoryService(_connectionString);
            var mappings = service.GetByProductId(product.Id);
            var ids = mappings.Select(x => x.ProductId).ToList();

            using var cservice = new CategoryService(_connectionString);
            var categories = cservice.Get(ids);

            var collection = (
                from category in categories
                let map = mappings.FirstOrDefault(x => x.ProductId == product.Id && x.CategoryId == category.Id)
                where map != null
                select new MappingViewModel
                {
                    Name = category.Name,
                    EntityMappedFromId = product.Id,
                    EntityMappedToId = category.Id,
                    Id = map.Id
                }).ToList();

            return collection;
        }

        /// <summary>
        /// Gets a custom fioelds view model for the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private IEnumerable<MappingViewModel> GetProductCustomFieldModels(IBaseEntity product)
        {
            using var service = new ProductCustomFieldService(_connectionString);
            var mappings = service.GetByProductId(product.Id);
            var ids = mappings.Select(x => x.ProductId).ToList();

            var cservice = new CustomFieldService(_connectionString);
            var fields = cservice.Get(ids);

            var collection = (
                from field in fields
                let map = mappings.FirstOrDefault(x => x.ProductId == product.Id && x.CustomFieldId == field.Id)
                where map != null
                select new MappingViewModel
                {
                    Name = field.Name,
                    EntityMappedFromId = product.Id,
                    EntityMappedToId = field.Id,
                    Id = map.Id,
                    CustomFieldValue = map.Value
                }).ToList();

            return collection;
        }

        #endregion


    }
}
