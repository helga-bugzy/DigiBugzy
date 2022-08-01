

namespace DigiBugzy.Services.Catalog.Products
{
    public interface IProductCategoryService
    {
        public ProductCategory GetById(int id);

        public List<ProductCategory> GetByProductId(int productId);

        public List<ProductCategory> GetByCategoryId(int categoryId);

        public void Delete(int id, bool hardDelete = false);

        public void Update(ProductCategory entity);

        public void Create(ProductCategory entity);
    }
}
