

global using DigiBugzy.Core.Domain.Products;

namespace DigiBugzy.Services.Catalog.Products
{
    public interface IProductService
    {
        public Product GetById(int id);

        public List<Product> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete = false);

        public void Update(Product entity);

        public void Create(Product entity);
    }
}
