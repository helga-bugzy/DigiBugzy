

using DigiBugzy.Core.Domain.xBase;

namespace DigiBugzy.Services.Catalog.Products
{
    public interface IProductCategoryService
    {
        #region Requests

        public ProductCategory GetById(int id);

        public List<ProductCategory> GetByProductId(int productId);

        public List<ProductCategory> GetByCategoryId(int categoryId);

        public IEnumerable<MappingViewModel> GetMappingViewModels(int productId);

        #endregion

        #region Commands


        public void Delete(int id, bool hardDelete = false);

        public void Update(ProductCategory entity);

        public void Create(ProductCategory entity);

        public void HandleCategoryMapping(int categoryId, int productId, bool isMapped, int digiAdminId);

        #endregion
    }
}
