

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
    }
}
