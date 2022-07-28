using Microsoft.EntityFrameworkCore;

namespace DigiBugzy.Services.Administration.CustomFields
{
    public class CustomFieldService : BaseService, ICustomFieldService
    {
        #region Fields



        #endregion

        #region Ctor

        public CustomFieldService(string connectionString) : base(connectionString)
        {

        }

        #endregion

        #region Public Methods

        

        /// <inheritdoc />
        public List<CustomField> Get(StandardFilter filter)
        {
            var query = dbContext.CustomFields.AsQueryable<CustomField>();

            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            if (filter.DigiAdminId.HasValue)
            {
                query = query.Where(x => x.DigiAdminId == filter.DigiAdminId);
            }
            

            if (filter.ClassificationId.HasValue)
            {
                query = query.Where(x => x.ClassificationId == filter.ClassificationId);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = filter.LikeSearch ? query.Where(x => x.Name.Contains(filter.Name)) : query.Where(x => x.Name.Equals(filter.Name));
            }

            if (!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == true);

            
            return query
                .Include(cft => cft.CustomFieldType)                
                .ToList();


        }

        /// <inheritdoc />
        public CustomField GetById(int id)
        {
            return dbContext.CustomFields.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public int Create(CustomField entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0) Update(entity);

            dbContext.CustomFields.Add(entity);
            dbContext.SaveChanges();

            if (entity.CustomFieldTypeId == 7)
            {


                var option = new CustomFieldListOption()
                {
                    CreatedOn = DateTime.Now,
                    CustomFieldId = entity.Id,
                    DigiAdminId = entity.DigiAdminId,
                    IsDeleted = false,
                    IsActive = true,
                    Value = @"Default Option"
                };

                dbContext.CustomFieldListOptions.Add(option);
                dbContext.SaveChanges();
            }

            return entity.Id;
        }

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete = false)
        {
            if (hardDelete)
            {
                var entity = GetById(id);
                if (entity!.Id > 0)
                {
                    dbContext.CustomFields.Remove(entity);
                    dbContext.SaveChanges();
                }
                else
                {
                    entity.IsDeleted = true;
                    entity.IsActive = false;
                    Update(entity);
                }
            }
        }

        /// <inheritdoc />
        public void Update(CustomField entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name,
            };

            //TODO check for duplicate


            dbContext.CustomFields.Update(entity);
            dbContext.SaveChanges();
        }

        #endregion
    }
}
