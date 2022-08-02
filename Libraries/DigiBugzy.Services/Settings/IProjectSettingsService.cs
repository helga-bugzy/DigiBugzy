
using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Services.Settings
{
    public interface IProjectSettingsService
    {
        #region Requests

        public ProjectSettings GetById(int id);

        public List<ProjectSettings> Get(int digiAdminId);

        #endregion

        #region Commands

        public int Create(ProjectSettings entity);

        public void Update(ProjectSettings entity);

        public void Delete(int id);

        #endregion
    }
}
