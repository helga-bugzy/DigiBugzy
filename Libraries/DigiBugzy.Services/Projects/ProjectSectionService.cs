﻿
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    public class ProjectSectionService: BaseService, IProjectSectionService
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

            var result = Get(new StandardFilter());
            result = result.Where(p => p.ProjectId == id).ToList();
            return result;
        }

        /// <inheritdoc />
        public List<ProjectSection> Get(StandardFilter filter, int projectId = 0)
        {
            var query = dbContext.ProjectSections
                
                .AsQueryable<ProjectSection>();

            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            if (filter.DigiAdminId.HasValue) 
                query = query.Where(x => x.DigiAdminId == filter.DigiAdminId);


            if (!string.IsNullOrEmpty(filter.Name)) 
                query = filter.LikeSearch ? query.Where(x => x.Name.Contains(filter.Name)) : query.Where(x => x.Name.Equals(filter.Name));

            if (!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == true);

            if (projectId > 0)
                query = query.Where(x => x.ProjectId == projectId);

            

            var result = query.ToList();

            //Get related projects
            foreach(var item in result)
            {
                var p = dbContext.Projects.FirstOrDefault(x => x.Id == item.ProjectId);
                if (p == null) continue;
                item.Project = p;
                item.ProjectName = p.Name;
            }

            return result.OrderBy(x => x.Name).ToList();
            

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

            try
            {
                var eentity = dbContext.ProjectSections.FirstOrDefault(p => p.ProjectId == entity.ProjectId && p.Name == entity.Name);
                if (eentity != null && eentity.Id == entity.Id)
                {
                    Update(entity);
                }
                else
                {

                    dbContext.ProjectSections.AddAsync(entity);
                    dbContext.SaveChanges();
                }

                return entity.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                if (e.InnerException != null)
                {
                    var c = e.InnerException.Message;
                }

                throw;
            }
        }


        #endregion
    }
}
