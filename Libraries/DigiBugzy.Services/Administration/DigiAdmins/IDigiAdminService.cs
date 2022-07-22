

global using DigiBugzy.Core.Domain.Administration.DigiAdmins;
global using DigiBugzy.Data.Common.xBaseObjects.FilterObjects;

namespace DigiBugzy.Services.Administration.DigiAdmins
{
    public interface IDigiAdminService
    {
        public DigiAdmin GetById(int id);

        public List<DigiAdmin> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete = false);

        public void Update(DigiAdmin entity);

        public void Create(DigiAdmin entity);
    }
}
