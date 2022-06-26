

namespace DigiBugzy.ApplicationLayer.Common.xBaseObjects.FilterObjects
{
    public class StandardFilter : IFilterObject
    {
        public int Id { get; set; }

        public int DigiAdminId { get; set; }

        public bool IsDelete { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public List<int> ClassificationId { get; set; }

        public List<int> CategoryIds { get; set; }

        public List<CustomFieldModel> CustomFields { get; set; }
    }

}
