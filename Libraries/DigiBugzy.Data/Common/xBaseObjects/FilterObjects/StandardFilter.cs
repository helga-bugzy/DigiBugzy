

namespace DigiBugzy.Data.Common.xBaseObjects.FilterObjects
{
    public class StandardFilter : IFilterObject
    {
        public int? Id { get; set; }

        public int? DigiAdminId { get; set; }

        public bool IncludeDeleted { get; set; }

        public bool IncludeInActive { get; set; }

        public bool LikeSearch { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public List<int> ClassificationId { get; set; } = new();

        public List<int> CategoryIds { get; set; } = new();

        public List<CustomFieldValue> CustomFields { get; set; } = new();

        public StandardFilter(
            bool includeInActive = false,
            bool includeDeleted = false,
            bool likeStringSearch = false)
        {
            IncludeInActive = includeInActive;
            IncludeDeleted = includeDeleted;
            LikeSearch = likeStringSearch;
        }
    }

}
