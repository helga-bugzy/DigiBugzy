using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Services.Settings
{
    public interface IGeneralSettingsService
    {
        #region Requests

        public GeneralSettings GetById(int id);

        public List<GeneralSettings> Get(int digiAdminId);

        #endregion

        #region Commands

        public int Create(GeneralSettings entity);

        public void Update(GeneralSettings entity);

        public void Delete(int id);

        #endregion
    }
}
