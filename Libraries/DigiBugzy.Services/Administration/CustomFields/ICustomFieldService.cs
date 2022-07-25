
global using DigiBugzy.Core.Domain.Administration.CustomFields;

namespace DigiBugzy.Services.Administration.CustomFields
{
    public interface ICustomFieldService
    {
        /// <summary>
        /// Gets a custom field item with it's related data via eager loading
        /// on hand of the primary key id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomField GetById(int id);

        /// <summary>
        /// Gets list of custom fields as per filter specifications
        /// and includes related data via eager loading
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<CustomField> Get(StandardFilter filter);

        /// <summary>
        /// Soft/hard deletes an existing custom field
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete = false);

        /// <summary>
        /// Updates an existing custom field
        /// </summary>
        /// <param name="entity"></param>
        public void Update(CustomField entity);

        /// <summary>
        /// Creates a new custom field
        /// </summary>
        /// <param name="entity"></param>
        public void Create(CustomField entity);
    }
}
