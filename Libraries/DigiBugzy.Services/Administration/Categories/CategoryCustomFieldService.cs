
namespace DigiBugzy.Services.Administration.Categories
{
    public class CategoryCustomFieldService: BaseService, ICategoryCustomFieldService
    {
        /// <inheritdoc />
        public CategoryCustomFieldService(string connectionString) : base(connectionString)
        {
        }

        #region Requests

        /// <inheritdoc />
        public List<CategoryCustomField> GetByCategoryId(int categoryId)
        {
            return dbContext.CategoryCustomFields.Where(c=> c.CategoryId == categoryId).ToList();
        }

        #endregion


    }
}
