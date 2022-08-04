
using Microsoft.EntityFrameworkCore;

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

        /// <inheritdoc />
        public List<CategoryCustomField> GetByCustomFieldId(int customFieldId)
        {
            return dbContext.CategoryCustomFields.Where(c => c.CustomFieldId == customFieldId).ToList();
        }

        /// <inheritdoc />
        public void Delete(CategoryCustomField entity, bool hardDelete = true)
        {
            if (hardDelete)
            {
                dbContext.CategoryCustomFields.Remove(entity);
                dbContext.SaveChanges();
            }
            else
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                dbContext.CategoryCustomFields.Update(entity);
                dbContext.SaveChanges();
            }
        }

        /// <inheritdoc />
        public void Delete(List<CategoryCustomField> entities, bool hardDelete = true)
        {
            if (hardDelete)
            {
                dbContext.CategoryCustomFields.RemoveRange(entities);
                dbContext.SaveChanges();
            }
            else
            {
                foreach (var entity in entities)
                {
                    entity.IsDeleted = true;
                    entity.IsActive = false;
                    dbContext.CategoryCustomFields.Update(entity);
                    dbContext.SaveChanges();
                }
            }
        }

        

        #endregion


    }
}
