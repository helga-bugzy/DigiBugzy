using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Data.Common.xBaseObjects;

namespace DigiBugzy.Services.Projects
{
    public class ProjectPrintingService : BaseService, IProjectPrintingService
    {
        #region Ctor

        /// <inheritdoc />
        public ProjectPrintingService(string connectionString) : base(connectionString)
        {
        }


        #endregion


        #region Requests

        /// <inheritdoc />
        public ProjectPrinting GetById(int id)
        {
            return dbContext.ProjectPrintings.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<ProjectPrinting> Get(ProjectPrintingFilter filter)
        {
            var query = dbContext.ProjectPrintings.AsQueryable<ProjectPrinting>();

            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            if (filter.DigiAdminId.HasValue)
                query = query.Where(x => x.DigiAdminId == filter.DigiAdminId);

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(x => x.Name == filter.Name);


            if (filter.ProjectId > 0)
                query = query.Where(x => x.ProjectId == filter.ProjectId);

            if (filter.ProjectSectionId > 0)
                query = query.Where(x => x.ProjectSectionId == filter.ProjectSectionId);

            if (filter.ProjectSectionPartId > 0)
                query = query.Where(x => x.ProjectSectionPartId == filter.ProjectSectionPartId);

         
            if (!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == true);


            return query.ToList();

        }

        #endregion

        #region Commands

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete)
        {
            Delete(GetById(id), hardDelete);
        }

        public void Delete(ProjectPrinting entity, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.ProjectPrintings.Remove(entity);
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
        public void Update(ProjectPrinting entity)
        {
            dbContext.ProjectPrintings.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public int Create(ProjectPrinting entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();

            return entity.Id;
        }

        #endregion
    }
}
