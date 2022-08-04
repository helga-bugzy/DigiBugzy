

global using DigiBugzy.Core.Domain.Administration.Classifications;

namespace DigiBugzy.Services.Administration.Classifications
{
    public interface IClassificationService
    {
        public Classification GetById(int id);

        public List<Classification> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete);

        public void Delete(Classification entity, bool hardDelete);

        public void Delete(List<Classification> entities, bool hardDelete);

        public void Update(Classification entity);

        public void Create(Classification entity);
    }
}
