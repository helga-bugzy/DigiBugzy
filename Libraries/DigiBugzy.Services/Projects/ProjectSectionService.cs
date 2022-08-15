
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    internal class ProjectSectionService: BaseService, IProjectSectionService
    {
        #region Ctor

        /// <inheritdoc />
        public ProjectSectionService(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Requests

        /// <inheritdoc />
        public ProjectSection GetById(int id)
        {
            return dbContext.ProjectSections.FirstOrDefault(p => p.Id == id);
        }

        /// <inheritdoc />
        public List<ProjectSection> GetByProjectId(int id)
        {
            return dbContext.ProjectSections.Where(p => p.ProjectId == id).ToList();
        }

        /// <inheritdoc />
        public List<ProjectSection> Get(StandardFilter filter)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Commands

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.ProjectSections.Remove(GetById(id));
                dbContext.SaveChanges();
            }
            else
            {
                var entity = GetById(id);
                if (entity == null) return;
                entity.IsActive = false;
                entity.IsDeleted = true;
                dbContext.ProjectSections.Update(entity);
                dbContext.SaveChanges();
            }
        }

        /// <inheritdoc />
        public void Update(ProjectSection entity)
        {
            dbContext.ProjectSections.Update(entity);
        }

        /// <inheritdoc />
        public int Create(ProjectSection entity)
        {
            var eentity = dbContext.ProjectSections.FirstOrDefault(p => p.ProjectId == entity.ProjectId && p.Name == entity.Name);
            if (eentity != null && eentity.Id == entity.Id)
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
