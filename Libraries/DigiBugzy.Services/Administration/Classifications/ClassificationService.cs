

namespace DigiBugzy.Services.Administration.Classifications
{
    public class ClassificationService : BaseService, IClassificationService
    {

        #region Fields




        #endregion

        #region Ctor

        public ClassificationService(string connectionString) : base(connectionString)
        {

        }



        #endregion

        #region Methods
        public void Create(Classification entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0) Update(entity);

            dbContext.SaveChanges();
        }

        public void Delete(int id, bool hardDelete = false)
        {
            if (hardDelete)
            {
                var entity = GetById(id);
                if (entity != null || entity.Id > 0)
                {
                    dbContext.Classifications.Remove(entity);
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

        public List<Classification> Get(StandardFilter filter)
        {
            var query = dbContext.Classifications.AsQueryable<Classification>();

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

        public Classification GetById(int id)
        {
            return dbContext.Classifications.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Classification entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name,
            };

            //TODO check for duplicate


            dbContext.Classifications.Update(entity);
        }

        #endregion
    }
}
