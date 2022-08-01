

global using DigiBugzy.Core.Domain.Products;
using DigiBugzy.Core.Domain.xBase;

namespace DigiBugzy.Services.Catalog.Products
{
    public interface IProductService
    {
        #region Requests

        /// <summary>
        /// Retrieves product on hand of it's primary key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loadProductComplete">Indicator if all product items should be loaded i.e product categories, documents, etc</param>
        /// <returns></returns>
        public Product GetById(int id, bool loadProductComplete = false);

        /// <summary>
        /// Gets a list of products on hand of the filter values
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="loadProductComplete">Indicator if all product items should be loaded i.e product categories, documents, etc</param>
        /// <returns></returns>
        public List<Product> Get(StandardFilter filter, bool loadProductComplete = false);



        #endregion


        #region Commands

        /// <summary>
        /// Deletes an existing product (soft/hard)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete = false);

        /// <summary>
        /// Updates details of an existing product
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Product entity);

        /// <summary>
        /// Creates a new product in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(Product entity);

        #endregion

        #region Mappings

        /// <summary>
        /// Retrieves list of all active and non-deleted custom fields for a classification with indication asto which ones are mapped
        /// </summary>
        /// <param name="categoryId">Category to be used for mapping indicator</param>
        /// <param name="classificationId">Classification to retrieve custom fields for</param>
        /// <returns></returns>
        public List<MappingViewModel> GetCustomFieldMappings(int categoryId, int classificationId);

        /// <summary>
        /// Maps or unmaps custom field to a category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="customFieldId"></param>
        /// <param name="isMapped"></param>
        public void HandleCustomFieldMapping(int categoryId, int customFieldId, bool isMapped);

        /// <summary>
        /// Retrieves list of all active and non-deleted categories for a classification with indication asto which ones are mapped
        /// </summary>
        /// <param name="categoryId">Category to be used for mapping indicator</param>
        /// <param name="classificationId">Classification to retrieve custom fields for</param>
        /// <returns></returns>
        public List<MappingViewModel> GetCategoryMappings(int categoryId, int classificationId);

        /// <summary>
        /// Maps or unmaps product to a category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="productId"></param>
        /// <param name="isMapped"></param>
        public void HandleCategoryMapping(int categoryId, int productId, bool isMapped);

        #endregion
    }
}
