
using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Services.Settings
{
    public class GeneralSettingsService: BaseService, IGeneralSettingsService
    {
        #region Ctor


        /// <inheritdoc />
        public GeneralSettingsService(string connectionString) : base(connectionString)
        {
        }

        #endregion


        #region Requets

        /// <inheritdoc />
        public GeneralSettings GetById(int id)
        {
            return dbContext.GeneralSettings.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<GeneralSettings> Get(int digiAdminId)
        {
            return dbContext.GeneralSettings.Where(x => x.DigiAdminId == digiAdminId).ToList();
        }

        #endregion

        /// <inheritdoc />
        public int Create(GeneralSettings entity)
        {
            dbContext.GeneralSettings.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        /// <inheritdoc />
        public void Update(GeneralSettings entity)
        {
            dbContext.GeneralSettings.Add(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
