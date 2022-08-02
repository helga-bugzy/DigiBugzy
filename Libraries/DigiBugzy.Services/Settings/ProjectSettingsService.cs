
using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Services.Settings
{
    public class ProjectSettingsService: BaseService, IProjectSettingsService
    {
        #region Ctor


        /// <inheritdoc />
        public ProjectSettingsService(string connectionString) : base(connectionString)
        {
        }

        #endregion


        #region Requets

        /// <inheritdoc />
        public ProjectSettings GetById(int id)
        {
            return dbContext.ProjectSettings.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<ProjectSettings> Get(int digiAdminId)
        {
            return dbContext.ProjectSettings.Where(x => x.DigiAdminId == digiAdminId).ToList();
        }

        #endregion

        /// <inheritdoc />
        public int Create(ProjectSettings entity)
        {
            dbContext.ProjectSettings.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        /// <inheritdoc />
        public void Update(ProjectSettings entity)
        {
            dbContext.ProjectSettings.Add(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
