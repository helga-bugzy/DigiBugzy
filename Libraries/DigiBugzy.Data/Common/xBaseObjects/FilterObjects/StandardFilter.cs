

namespace DigiBugzy.Data.Common.xBaseObjects.FilterObjects
{
    public class StandardFilter : IFilterObject
    {
        public int Id { get; set; }

        public int DigiAdminId { get; set; }

        public bool IncludeDeleted { get; set; }

        public bool IncludeInActive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public List<int> ClassificationId { get; set; }

        public List<int> CategoryIds { get; set; }

        public List<CustomFieldValue> CustomFields { get; set; }

        public StandardFilter(bool includeInActive = false, bool includeDeleted = false)
        {
            IncludeInActive = includeInActive;
            IncludeDeleted = includeDeleted;
        }
    }

}
