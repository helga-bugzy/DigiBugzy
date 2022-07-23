

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

        #region Methods
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

            if (filter.ParentId.HasValue)
            {
                query = query.Where(x => x.ParentId == filter.ParentId.Value);
            }

            if (filter.ClassificationId.HasValue)
            {
                query = query.Where(x => x.ClassificationId == filter.ClassificationId);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                if (filter.LikeSearch)
                    query = query.Where(x => x.Name.Contains(filter.Name));
                else
                    query = query.Where(x => x.Name.Equals(filter.Name));
            }

            if (!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == true);


            return query.ToList();


        }

        public Category GetById(int id)
        {
            return dbContext.Categories.FirstOrDefault(x => x.Id == id);
        }

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
    }
}
