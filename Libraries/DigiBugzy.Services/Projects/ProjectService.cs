using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    public class ProjectService :BaseService, IProjectService
    {
        

        #region Ctor

        /// <inheritdoc />
        public ProjectService(string connectionString) : base(connectionString)
        {

           
        }
        #endregion

       

        public List<Project> Get(StandardFilter filter)
        {
            var query = dbContext.Projects.AsQueryable<Project>();

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

        public Project GetById(int id)
        {
            return dbContext.Projects.FirstOrDefault(p => p.Id == id);
        }

        #region Commands

        public int Create(Project entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0) Update(entity);
            else
            {
                dbContext.Add(entity);
                dbContext.SaveChanges();

            }

            return entity.Id;
        }

        public void Delete(int id, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.Projects.Remove(GetById(id));
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

        public void Update(Project entity)
        {
            dbContext.Projects.Update(entity);
            dbContext.SaveChanges();
        }

        #endregion


    }
}
