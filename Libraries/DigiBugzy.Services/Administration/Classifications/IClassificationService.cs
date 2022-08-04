

global using DigiBugzy.Core.Domain.Administration.Classifications;

namespace DigiBugzy.Services.Administration.Classifications
{
    public interface IClassificationService
    {
        public Classification GetById(int id);

        public List<Classification> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete = false);

        public void Delete(Classification entity, bool hardDelete = true);

        public void Delete(List<Classification> entities, bool hardDelete = true);

        public void Update(Classification entity);

        public void Create(Classification entity);
    }
}
