


namespace DigiBugzy.Services.Administration.CustomFields
{
    public interface ICustomFieldTypeService
    {
        public CustomFieldType GetById(int id);

        public List<CustomFieldType> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete = false);

        public void Update(CustomFieldType entity);

        public void Create(CustomFieldType entity);

        public CustomFieldListOption GetListOptionById(int optionId);

        public List<CustomFieldListOption> GetListOptions(int customFieldId, StandardFilter filter);

        public void DeleteListOption(int optionId, bool hardDelete = false);

        public void AddListOption(CustomFieldListOption entity);

        public void UpdateListOption(CustomFieldListOption entity);
    }
}
