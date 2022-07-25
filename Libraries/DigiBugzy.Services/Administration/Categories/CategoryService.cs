

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
                .Include(admin => admin.CustomFieldMappings)
                .ThenInclude(cfield => cfield.CustomField)
                .Include(admin => admin.DigiAdmin)
                .ToList();


        }

        /// <inheritdoc />
        public Category GetById(int id)
        {

            var query = dbContext.Categories.Where(c => c.Id == id)
                .Include(admin => admin.CustomFieldMappings)
                .ThenInclude(cfield => cfield.CustomField)
                .Include(admin => admin.DigiAdmin);

            return query.FirstOrDefault();
        }

        /// <inheritdoc />
        public void Create(Category entity)
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
        }

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete = false)
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

                var x = category.CustomFieldMappings.FirstOrDefault(x => x.CustomFieldId == cf.Id && cf.IsDeleted == false && cf.IsActive);
                if (x != null && x.CategoryId == categoryId)
                {
                    result.IsMapped = true;
                }
                
                results.Add(result);

            }


            return results;
        }


        #endregion 

        #endregion
    }
}
