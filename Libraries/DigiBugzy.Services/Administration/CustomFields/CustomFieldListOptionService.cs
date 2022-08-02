

namespace DigiBugzy.Services.Administration.CustomFields
{
    public class CustomFieldListOptionService: BaseService, ICustomFieldListOptionsService
    {
        #region Ctor

        /// <inheritdoc />
        public CustomFieldListOptionService(string connectionString) : base(connectionString)
        {

        }

        #endregion

        #region Requests

        /// <inheritdoc />
        public CustomFieldListOption GetById(int id)
        {
            return dbContext.CustomFieldListOptions.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<CustomFieldListOption> GetForCustomFieldId(int id)
        {
            return dbContext.CustomFieldListOptions.Where(x => x.CustomFieldId == id).ToList();
        }

        #endregion

        #region Commands

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete = false)
        {
            if (hardDelete)
            {
                dbContext.CustomFieldListOptions.Remove(GetById(id));
                dbContext.SaveChanges();
            }
            else
            {
                var entity = GetById(id);
                entity.IsDeleted = true;
                entity.IsActive = false;
                Update(entity);
            }
        }

        /// <inheritdoc />
        public void Update(CustomFieldListOption entity)
        {
            dbContext.CustomFieldListOptions.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public int Create(CustomFieldListOption entity)
        {
            dbContext.CustomFieldListOptions.Add(entity);
            dbContext.SaveChanges();

            return entity.Id;
        }

        #endregion
    }
}
