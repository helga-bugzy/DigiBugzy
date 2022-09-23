

using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Services.Administration.CustomFields;

namespace DigiBugzy.Services.Administration.Categories
{
    public class CategoryService : BaseService, ICategoryService
    {
        #region Fields



        #endregion

        #region Ctor

        public CategoryService(string connectionString) : base(connectionString)
        {

        }

        #endregion

        #region Public Methods

        #region Category

        #region Requests


        /// <inheritdoc />
        public List<Category> Get(StandardFilter filter)
        {
            var query = dbContext.Categories.AsQueryable<Category>();


            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            if (filter.DigiAdminId.HasValue)
            {
                query = query.Where(x => x.DigiAdminId == filter.DigiAdminId);
            }

            if (filter.OnlyParents)
            {
                query = query.Where(x => x.ParentId == null);
            }
            else if (filter.ParentId.HasValue)
            {
                query = query.Where(x => x.ParentId == filter.ParentId.Value);
            }

            if (filter.ClassificationId.HasValue)
            {
                query = query.Where(x => x.ClassificationId == filter.ClassificationId);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = filter.LikeSearch ? query.Where(x => x.Name.Contains(filter.Name) && x.ParentId == null) : query.Where(x => x.Name.Equals(filter.Name) && x.ParentId == null);
            }

     
            if (!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == true);


            return query
               // .Include(admin => admin.CustomFieldMappings)
               // .ThenInclude(cfield => cfield.CustomField)
               .ToList();


        }

        /// <inheritdoc />
        public List<Category> Get(List<int> categoryIds)
        {
            return dbContext.Categories.Where(x => categoryIds.Contains(x.Id)).ToList();
        }

        /// <inheritdoc />
        public Category GetById(int id)
        {

            var query = dbContext.Categories.Where(c => c.Id == id);
               // .Include(admin => admin.CustomFieldMappings)
               // .ThenInclude(cfield => cfield.CustomField);

            return query.FirstOrDefault();
        }

        #endregion

        #region Commands

        /// <inheritdoc />
        public int Create(Category entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0)
                Update(entity);
            else
                dbContext.Categories.Add(entity);

            dbContext.SaveChanges();

            return entity.Id;
        }

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete)
        {

            var entity = GetById(id);
            if (entity == null) return;

            if (hardDelete)
            {
                try
                {
                    //Try hard delete
                    dbContext.Categories.Remove(entity);
                    dbContext.SaveChanges();
                }
                catch
                {
                    //Try softdelete
                    entity.IsDeleted = true;
                    entity.IsActive = false;
                    Update(entity);
                }
            }
            else
            {

                entity.IsDeleted = true;
                entity.IsActive = false;
                Update(entity);
            }

        }

        /// <inheritdoc />
        public void Delete(List<Category> entities, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.Categories.RemoveRange(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    entity.IsDeleted = true;
                    entity.IsActive = false;
                    Update(entity);
                }
            }
        }

        /// <inheritdoc />
        public void Delete(Category entity, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.Categories.Remove(entity);
                dbContext.SaveChanges();
            }
            else
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                Update(entity);
            }


        }

        /// <inheritdoc />
        public void Update(Category entity)
        {
          

            //TODO check for duplicate


            dbContext.Categories.Update(entity);
            dbContext.SaveChanges();
        }

        #endregion

        #endregion

        #region Custom Fields

        /// <inheritdoc />
        public List<MappingViewModel> GetCustomFieldMappings(int categoryId, int classificationId)
        {
            var results = new List<MappingViewModel>();

            if (categoryId <= 0 || classificationId <= 0) return results;


            using var customFieldService = new CustomFieldService(connectionString: _connectionString);
            var customFields = customFieldService.Get(new StandardFilter { ClassificationId = classificationId });
            if (customFields.Count <= 0) return results;


            var category = GetById(categoryId);
            foreach (var cf in customFields)
            {
                var result = new MappingViewModel
                {
                    Name = cf.Name,
                    TypeId = cf.CustomFieldTypeId,
                    TypeName = cf.CustomFieldType.Name,
                    IsMapped = false,
                    EntityMappedToId = cf.Id,
                    EntityMappedFromId = categoryId             //Set by default, not always true
                };

                if (category.CustomFieldMappings == null)
                {
                    using var categoryCustomFieldService = new CategoryCustomFieldService(_connectionString);
                    category.CustomFieldMappings = categoryCustomFieldService.GetByCategoryId(categoryId);
                }
                var x = category.CustomFieldMappings.FirstOrDefault(x => x.CustomFieldId == cf.Id && cf.IsDeleted == false && cf.IsActive);
                if (x != null && x.CategoryId == categoryId)
                {
                    result.IsMapped = true;
                }
                
                results.Add(result);

            }


            return results;
        }

        /// <inheritdoc />
        public void HandleCustomFieldMapping(int categoryId, int customFieldId, bool isMapped, bool includeChildCategories)
        {

            using var categoryCustomFieldService = new CategoryCustomFieldService(_connectionString);
            var categoryCustomFields = categoryCustomFieldService.GetByCategoryId(categoryId);

            var category = GetById(categoryId);
            var existingMapping = categoryCustomFields.FirstOrDefault(c => c.CustomFieldId == customFieldId);
            if (existingMapping == null && isMapped)
            {
                var mapping = new CategoryCustomField
                {
                    CategoryId = categoryId,
                    CustomFieldId = customFieldId,
                    DigiAdminId = category.DigiAdminId,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };
                categoryCustomFieldService.Create(mapping);
            }
            else if (!isMapped)
            {
                categoryCustomFieldService.Delete(existingMapping, true);
            }

            if (!includeChildCategories) return;
            {
                var children = dbContext.Categories.Where(x => x.ParentId == categoryId).ToList();
                foreach (var child in children)
                {
                    HandleCustomFieldMapping(child.Id, customFieldId, isMapped, true);
                }
            }
        }


        #endregion

       
        #endregion
    }
}
