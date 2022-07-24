


namespace DigiBugzy.Services.Administration.CustomFields
{
    public class CustomFieldTypeService : BaseService, ICustomFieldTypeService
    {

        #region Ctor

        public CustomFieldTypeService(string connectionString) : base(connectionString)
        {
            
        }

        #endregion

        #region Public Methods


        public void Create(CustomFieldType entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0)
                Update(entity);
            else
                dbContext.CustomFieldTypes.Add(entity);

            dbContext.SaveChanges();
        }

        public void Delete(int id, bool hardDelete = false)
        {
            var entity = GetById(id);
            if (entity == null) return;

            if (hardDelete)
            {
                dbContext.CustomFieldTypes.Remove(entity);
                dbContext.SaveChanges();
            }
            else
            {

                entity.IsDeleted = true;
                entity.IsActive = false;
                Update(entity);
            }
        }

        public List<CustomFieldType> Get(StandardFilter filter)
        {
            var query = dbContext.CustomFieldTypes.AsQueryable<CustomFieldType>();

            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            if (filter.DigiAdminId.HasValue)
            {
                query = query.Where(x => x.DigiAdminId == filter.DigiAdminId);
            }
            
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = filter.LikeSearch ? query.Where(x => x.Name.Contains(filter.Name)) : query.Where(x => x.Name.Equals(filter.Name));
            }

            if (!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == true);


            return query.ToList();

        }

        public CustomFieldType GetById(int id)
        {
            return dbContext.CustomFieldTypes.FirstOrDefault(x => x.Id == id);
        }

        public void Update(CustomFieldType entity)
        {
            dbContext.CustomFieldTypes.Update(entity);
            dbContext.SaveChanges();
        }


        #endregion
    }
}
