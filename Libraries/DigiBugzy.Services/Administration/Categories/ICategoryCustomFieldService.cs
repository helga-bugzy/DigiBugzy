﻿

namespace DigiBugzy.Services.Administration.Categories
{
    public interface ICategoryCustomFieldService
    {
        /// <summary>
        /// Retrieves a list of category-custom field mappings for a specific category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<CategoryCustomField> GetByCategoryId(int categoryId);

        /// <summary>
        /// Retrieves a list of category-custom field mappings for a specific custom field
        /// </summary>
        /// <param name="customFieldId"></param>
        /// <returns></returns>
        public List<CategoryCustomField> GetByCustomFieldId(int customFieldId);

        public int Create(CategoryCustomField entity);

        public void Delete(CategoryCustomField entity, bool hardDelete);

        public void Delete(List<CategoryCustomField> entities, bool hardDelete);
    }
}
