
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    public class ProjectSectionPartService: BaseService, IProjectSectionPartService
    {
        #region Ctor

        /// <inheritdoc />
        public ProjectSectionPartService(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Requests

        /// <inheritdoc />
        public ProjectSectionPart GetById(int id)
        {
            return dbContext.ProjectSectionParts.FirstOrDefault(p => p.Id == id);
        }

        /// <inheritdoc />
        public List<ProjectSectionPart> GetByProjectSectionId(int id)
        {
            return dbContext.ProjectSectionParts.Where(p => p.ProjectSectionId == id).ToList();
        }

        /// <inheritdoc />
        public List<ProjectSectionPart> Get(StandardFilter filter, int projectSectionId = 0)
        {
            var query = dbContext.ProjectSectionParts.AsQueryable<ProjectSectionPart>();

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

            if (projectSectionId > 0)
                query = query.Where(x => x.ProjectSectionId == projectSectionId);

            return query.ToList();

        }

        #endregion

        #region Commands

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.ProjectSectionParts.Remove(GetById(id));
                dbContext.SaveChanges();
            }
            else
            {
                var entity = GetById(id);
                if (entity == null) return;
                entity.IsDeleted = true;
                entity.IsActive = false;
                Update(entity);
            }
        }

        /// <inheritdoc />
        public void Update(ProjectSectionPart entity)
        {
            dbContext.ProjectSectionParts.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public int Create(ProjectSectionPart entity)
        {
            var eentity = dbContext.ProjectSectionParts.FirstOrDefault(p => p.ProjectSectionId == entity.ProjectSectionId && p.Name == entity.Name);
            if(eentity != null && eentity.Id == entity.Id)
            {
                Update(entity);
            }
            else
            {
                dbContext.Add(entity);
                dbContext.SaveChanges();
            }

            return entity.Id;
        }

        #endregion
    }
}
