
using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Services.Settings
{
    public class ProductSettingsService: BaseService, IProductSettingsService
    {
        #region Ctor


        /// <inheritdoc />
        public ProductSettingsService(string connectionString) : base(connectionString)
        {
        }

        #endregion


        #region Requets

        /// <inheritdoc />
        public ProductSettings GetById(int id)
        {
            return dbContext.ProductSettings.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<ProductSettings> Get(int digiAdminId)
        {
            return dbContext.ProductSettings.Where(x => x.DigiAdminId == digiAdminId).ToList();
        }

        #endregion

        /// <inheritdoc />
        public int Create(ProductSettings entity)
        {
            dbContext.ProductSettings.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        /// <inheritdoc />
        public void Update(ProductSettings entity)
        {
            dbContext.ProductSettings.Add(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
