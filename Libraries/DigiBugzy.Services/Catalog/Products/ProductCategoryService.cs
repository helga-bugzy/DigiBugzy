using DigiBugzy.Core.Domain.xBase;
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
            var categories = cservice.Get(ids);

            var collection = (
                from category in categories
                let map = mappings.FirstOrDefault(x => x.ProductId == productId && x.CategoryId == category.Id)
                where map != null
                select new MappingViewModel
                {
                    Name = category.Name,
                    EntityMappedFromId = productId,
                    EntityMappedToId = category.Id,
                    Id = map.Id
                }).ToList();

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
        public void Delete(int id, bool hardDelete = false)
        {


            var entity = GetById(id);
            if (entity == null) return;

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
        public void Update(ProductCategory entity)
        {
            dbContext.ProductCategories.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void HandleCategoryMapping(int categoryId, int productId, bool isMapped, int digiAdminId)
        {
            var mapping =
                dbContext.ProductCategories.Where(x => x.CategoryId == categoryId && x.ProductId == productId);
            if (!mapping.Any())
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


        }

        #endregion

        #endregion


    }
}
