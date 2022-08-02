
using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Services.Settings
{
    public interface IProductSettingsService
    {
        #region Requests

        public ProductSettings GetById(int id);

       public List<ProductSettings> Get(int digiAdminId);

       #endregion

       #region Commands

        public int Create(ProductSettings entity);

        public void Update(ProductSettings entity);

        public void Delete(int id);

       #endregion
    }
}
