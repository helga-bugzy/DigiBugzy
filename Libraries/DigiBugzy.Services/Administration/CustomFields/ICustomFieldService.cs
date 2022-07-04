
global using DigiBugzy.Core.Domain.Administration.CustomFields;

namespace DigiBugzy.Services.Administration.CustomFields
{
    public interface ICustomFieldService
    {
        public CustomField GetById(int id);

        public List<CustomField> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete = false);

        public void Update(CustomField entity);

        public void Create(CustomField entity);
    }
}
