

using System.ComponentModel.DataAnnotations.Schema;
using DigiBugzy.Core.Constants;

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
        public List<ProductCategory> GetByCategoryId(int categoryId)
        {
            return dbContext.ProductCategories.Where(x => x.CategoryId == categoryId).ToList();
        }


        public void Create(ProductCategory entity)
        {
            dbContext.ProductCategories.Add(entity);
            dbContext.SaveChanges();
        }

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



        public void Update(ProductCategory entity)
        {
            dbContext.ProductCategories.Update(entity);
            dbContext.SaveChanges();
        } 

        #endregion
    }
}
