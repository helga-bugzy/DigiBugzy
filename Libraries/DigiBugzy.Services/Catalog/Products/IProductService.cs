

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
        public void Delete(int id, bool hardDelete = true);

        public void Delete(Product entity, bool hardDelete = true);

        public void Delete(List<Product> entities, bool hardDelete = true);



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

        
    }
}
