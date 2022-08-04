using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Core.Enumerations;
using DigiBugzy.Services.Administration.Categories;

namespace DigiBugzy.Services.Catalog.Products
{
    
    public class ProductCategoryService : BaseService, IProductCategoryService
    {

        #region Fields

        #endregion

        #region Ctor

        public ProductCategoryService(string connectionString) : base(connectionString)
        {

        }

        #endregion


        #region Methods

        #region Requests
        /// <inheritdoc />
        public ProductCategory GetById(int id)
        {
            return dbContext.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<ProductCategory> GetByProductId(int productId)
        {
            return dbContext.ProductCategories.Where(x => x.ProductId == productId).ToList();
        }

        /// <inheritdoc />
        public IEnumerable<MappingViewModel> GetMappingViewModels(int productId)
        {
            using var service = new ProductCategoryService(_connectionString);
            var mappings = service.GetByProductId(productId);
            var ids = mappings.Select(x => x.ProductId).ToList();

            using var cservice = new CategoryService(_connectionString);
            var categories = cservice.Get(new StandardFilter{ClassificationId = (int)ClassificationsEnum.Product });

            var collection = new List<MappingViewModel>();

            foreach (var category in categories)
            {
                var model = new MappingViewModel
                {
                    Name = category.Name,
                    ParentId = category.ParentId,
                    CreatedOn = category.CreatedOn,
                    DigiAdminId = category.DigiAdminId,
                    EntityMappedFromId = productId,
                    EntityMappedToId = category.Id
                };

                var item = mappings.Where(x => x.CategoryId == category.Id);
                model.IsMapped = item.Any();
                collection.Add(model);
            }

            return collection;
        }

        /// <inheritdoc />
        public List<ProductCategory> GetByCategoryId(int categoryId)
        {
            return dbContext.ProductCategories.Where(x => x.CategoryId == categoryId).ToList();
        }

        #endregion





        #region Commands

        /// <inheritdoc />
        public void Create(ProductCategory entity)
        {
            dbContext.ProductCategories.Add(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete)
        {

            Delete(GetById(id), hardDelete);
            

            


        }

        /// <inheritdoc />
        public void Delete(ProductCategory entity, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.ProductCategories.Remove(entity);
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
        public void Delete(List<ProductCategory> entities, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.ProductCategories.RemoveRange(entities);
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


        /// <inheritdoc />
        public void Update(ProductCategory entity)
        {
            dbContext.ProductCategories.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void HandleCategoryMapping(int categoryId, int productId, bool isMapped, int digiAdminId, bool applyToChildCategories = true)
        {
            var mapping =
                dbContext.ProductCategories.Where(x => x.CategoryId == categoryId && x.ProductId == productId);
            if (!mapping.Any() && isMapped)
            {
                Create(new ProductCategory
                {
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    DigiAdminId = digiAdminId,
                    ProductId = productId,
                    CategoryId = categoryId
                });
            }
            else if(isMapped == false)
            {
                foreach (var item in mapping)
                {
                    Delete(item.Id, true);
                }
            }

            if (applyToChildCategories) HandleChildCategoryMapping(categoryId, productId, isMapped, digiAdminId);

        }

        
        


        /// <inheritdoc />
        public void HandleChildCategoryMapping(int categoryId, int productId, bool isMapped, int digiAdminId)
        {
            using var categoryService = new CategoryService(_connectionString);
            var categories = categoryService.Get(new StandardFilter
            {
                ClassificationId = (int)ClassificationsEnum.Product,
                ParentId = categoryId
            });

            foreach (var category in categories)
            {
                var mapping =
                    dbContext.ProductCategories.Where(x => x.CategoryId == categoryId && x.ProductId == productId);
                if (!mapping.Any() && isMapped)
                {
                    Create(new ProductCategory
                    {
                        IsActive = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        DigiAdminId = digiAdminId,
                        ProductId = productId,
                        CategoryId = categoryId
                    });
                }
                else if (isMapped == false)
                {
                    foreach (var item in mapping)
                    {
                        Delete(item.Id, true);
                    }
                }

                HandleChildCategoryMapping(categoryId, productId, isMapped, digiAdminId);
            }

        }

        #endregion

        #endregion


    }
}
