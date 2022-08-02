
using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Services.Settings
{
    public interface IAdministrationSettingsService
    {
        #region Requests

        public AdministrationSettings GetById(int id);

        public List<AdministrationSettings> Get(int digiAdminId);

        #endregion

        #region Commands

        public int Create(AdministrationSettings entity);

        public void Update(AdministrationSettings entity);

        public void Delete(int id);

        #endregion
    }
}
