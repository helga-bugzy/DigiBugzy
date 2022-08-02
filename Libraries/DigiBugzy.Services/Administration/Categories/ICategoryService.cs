
global using DigiBugzy.Core.Domain.Administration.Categories;
using DigiBugzy.Core.Domain.xBase;

namespace DigiBugzy.Services.Administration.Categories
{
    public interface ICategoryService
    {
        /// <summary>
        /// Retrieves a specific category on hand of it's id
        /// It includes mapped entities via eager loading
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetById(int id);

        /// <summary>
        /// Retrieves a list of categories on hand of the filter forwarded
        /// It includes mapped entities via eager loading
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Category> Get(StandardFilter filter);

        /// <summary>
        /// Gets a list of categories on hand of their id's
        /// </summary>
        /// <returns></returns>
        public List<Category> Get(List<int> categoryIds);

        /// <summary>
        /// Hard/Soft delete a category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete = false);

        /// <summary>
        /// Update changes to a category in the database
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Category entity);

        /// <summary>
        /// Adds a new category to the database
        /// </summary>
        /// <param name="entity"></param>
        public int Create(Category entity);

        ///// <summary>
        ///// Retrieves list of all active and non-deleted custom fields for a classification with indication asto which ones are mapped
        ///// </summary>
        ///// <param name="categoryId">Category to be used for mapping indicator</param>
        ///// <param name="classificationId">Classification to retrieve custom fields for</param>
        ///// <returns></returns>
        //public List<MappingViewModel> GetCustomFieldMappings(int categoryId, int classificationId);

        ///// <summary>
        ///// Maps or unmaps custom field to a category
        ///// </summary>
        ///// <param name="categoryId"></param>
        ///// <param name="customFieldId"></param>
        ///// <param name="isMapped"></param>
        //public void HandleCustomFieldMapping(int categoryId, int customFieldId, bool isMapped);
        
    }
}
