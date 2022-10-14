
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    /// <summary>
    /// Service for project document database tasks
    /// </summary>
    public class ProjectDocumentService: BaseService, IProjectDocumentService
    {
        #region Ctor

        /// <inheritdoc />
        public ProjectDocumentService(string connectionString) : base(connectionString)
        {
        }


        #endregion


        #region Requests

        /// <inheritdoc />
        public ProjectDocument GetById(int id)
        {
            return dbContext.ProjectDocuments.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<ProjectDocument> Get(ProjectDocumentFilter filter)
        {
            var query = dbContext.ProjectDocuments.AsQueryable<ProjectDocument>();

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

            if(filter.ProjectSectionPartId > 0)
                query = query.Where(x => x.ProjectSectionPartId == filter.ProjectSectionPartId);

            if(filter.Only3DPrintingDocument)
                query = query.Where(x => x.Is3DPrintingDocument == true);
            else if(filter.OnlyInstructions)
                query = query.Where(x => x.IsInstructions == true);
            else if (filter.OnlyPlans)
                query = query.Where(x => x.IsPlans == true);
            else if(filter.OnlySpecifications)
                query = query.Where(x => x.IsSpecifications == true);

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
            if (hardDelete)
            {
                dbContext.ProjectDocuments.Remove(GetById(id));
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

        /// <inheritdoc />
        public void Update(ProjectDocument entity)
        {
            dbContext.ProjectDocuments.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public int Create(ProjectDocument entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();

            return entity.Id;
        }

        #endregion
    }
}
