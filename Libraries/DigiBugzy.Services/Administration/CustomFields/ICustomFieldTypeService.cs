


namespace DigiBugzy.Services.Administration.CustomFields
{
    public interface ICustomFieldTypeService
    {
        public CustomFieldType GetById(int id);

        public List<CustomFieldType> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete = false);

        public void Update(CustomFieldType entity);

        public void Create(CustomFieldType entity);
    }
}
