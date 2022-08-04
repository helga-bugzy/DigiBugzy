

using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Services.Administration.CustomFields;
using Microsoft.EntityFrameworkCore;

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
                query = filter.LikeSearch ? query.Where(x => x.Name.Contains(filter.Name)) : query.Where(x => x.Name.Equals(filter.Name));
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
            var filter = new StandardFilter
            {
                Name = entity.Name,
            };

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


            using var cfService = new CustomFieldService(connectionString: _connectionString);
            var cfCollection = cfService.Get(new StandardFilter { ClassificationId = classificationId });
            if (cfCollection.Count <= 0) return results;


            var category = GetById(categoryId);
            foreach (var cf in cfCollection)
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
         
            
            var entity = dbContext.CategoryCustomFields.FirstOrDefault(x =>
                x.CategoryId == categoryId && x.CustomFieldId == customFieldId);

            if (entity == null && isMapped)
            {
                entity = new CategoryCustomField
                {
                    CustomFieldId = customFieldId,
                    CategoryId = categoryId,
                    DigiAdminId = 1,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };

                dbContext.CategoryCustomFields.Add(entity);
                dbContext.SaveChanges();

            }
            else
            {
                if (!isMapped)
                {
                    dbContext.CategoryCustomFields.Remove(entity!);
                    dbContext.SaveChanges();
                }

                
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
