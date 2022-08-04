

using DigiBugzy.Core.Domain.xBase;

namespace DigiBugzy.Services.Catalog.Products
{
    public interface IProductCustomFieldService
    {
        /// <summary>
        /// Gets a specific mapping on hand of it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductCustomField GetById(int id);

        /// <summary>
        /// Gets all mappings for a specific product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<ProductCustomField> GetByProductId(int productId);


        /// <summary>
        /// Get all mappings for a specific custom field
        /// </summary>
        /// <param name="customFieldId"></param>
        /// <returns></returns>
        public List<ProductCustomField> GetByCustomFieldId(int customFieldId);

        /// <summary>
        /// Generates view models with detailed mapping information and values
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<MappingViewModel> GetMappingViewModels(int productId);

        /// <summary>
        /// Deletes and existing mapping
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete = false);

        public void Delete(ProductCustomField entity, bool hardDelete = true);

        public void Delete(List<ProductCustomField> entity, bool hardDelete = true);

        /// <summary>
        /// Updates an existing mapping
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ProductCustomField entity);

        /// <summary>
        /// Creates a new mapping
        /// </summary>
        /// <param name="entity"></param>
        public void Create(ProductCustomField entity);
    }
}
