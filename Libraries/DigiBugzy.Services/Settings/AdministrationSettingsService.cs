
using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Services.Settings
{
    public class AdministrationSettingsService: BaseService, IAdministrationSettingsService
    {
        #region Ctor


        /// <inheritdoc />
        public AdministrationSettingsService(string connectionString) : base(connectionString)
        {
        }

        #endregion


        #region Requets

        /// <inheritdoc />
        public AdministrationSettings GetById(int id)
        {
            return dbContext.AdministrationSettings.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<AdministrationSettings> Get(int digiAdminId)
        {
            return dbContext.AdministrationSettings.Where(x => x.DigiAdminId == digiAdminId).ToList();
        }

        #endregion

        /// <inheritdoc />
        public int Create(AdministrationSettings entity)
        {
            dbContext.AdministrationSettings.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        /// <inheritdoc />
        public void Update(AdministrationSettings entity)
        {
            dbContext.AdministrationSettings.Add(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
