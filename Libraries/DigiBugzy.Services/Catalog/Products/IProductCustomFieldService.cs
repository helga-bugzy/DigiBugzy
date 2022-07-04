

namespace DigiBugzy.Services.Catalog.Products
{
    public interface IProductCustomFieldService
    {
        public ProductCategory GetById(int id);

        public ProductCategory GetByProductId(int productId);

        public ProductCategory GetByCustomFieldId(int customFieldId);
        

        public void Delete(int id, bool hardDelete = false);

        public void Update(Product entity);

        public void Create(Product entity);
    }
}
