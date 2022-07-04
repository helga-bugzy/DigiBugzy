

namespace DigiBugzy.Services.Administration.DigiAdmins
{
    public class DigiAdminService : BaseService, IDigiAdminService
    {
        #region Fields

       

        
        #endregion

        #region Ctor

        public DigiAdminService(string connectionString): base(connectionString)
        {
            
        }



        #endregion



        #region Methods

        public void Create(DigiAdmin entity)
        {
            var filter = new StandardFilter{  
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
                    dbContext.DigiAdmins.Remove(entity);
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

        public List<DigiAdmin> Get(StandardFilter filter)
        {
            var query = dbContext.DigiAdmins.AsQueryable<DigiAdmin>();

            if(filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                if (filter.LikeSearch)
                    query = query.Where(x => x.Name.Contains(filter.Name));
                else
                    query = query.Where(x => x.Name.Equals(filter.Name));
            }

            if(!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == false);


            return query.ToList();           

            
        }

        public DigiAdmin GetById(int id)
        {
            return dbContext.DigiAdmins.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(DigiAdmin entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name,                
            };

            //TODO check for duplicate


            dbContext.DigiAdmins.Update(entity);
        }

        #endregion
    }
}
