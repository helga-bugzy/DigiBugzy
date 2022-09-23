
using DigiBugzy.Core.Domain.BusinessEntities;

namespace DigiBugzy.Services.ContactBase.BusinessEntities
{
    public interface  IBusinessEntityService
    {
        #region Requests

        /// <summary>
        /// Retrieves product on hand of it's primary key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loadComplete">Indicator if all sub items should be loaded i.e categories, documents, etc</param>
        /// <returns></returns>
        public BusinessEntity GetById(int id, bool loadComplete = false);

        /// <summary>
        /// Gets a list of products on hand of the filter values
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="loadComplete">Indicator if all sub items should be loaded i.e categories, documents, etc</param>
        /// <returns></returns>
        public List<BusinessEntity> Get(StandardFilter filter, bool loadComplete = false);

        


        #endregion


        #region Commands

        /// <summary>
        /// Deletes an existing business entity (soft/hard)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete);

        public void Delete(BusinessEntity entity, bool hardDelete);

        public void Delete(List<BusinessEntity> entities, bool hardDelete);


        /// <summary>
        /// Updates details of an existing product
        /// </summary>
        /// <param name="entity"></param>
        public void Update(BusinessEntity entity);

        /// <summary>
        /// Creates a new product in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(BusinessEntity entity);

        #endregion
    }
}
