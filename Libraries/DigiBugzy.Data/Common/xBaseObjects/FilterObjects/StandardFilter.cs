

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

        public bool OnlyParents { get; set; }

        public int? ClassificationId { get; set; } 

        public int? CategoryId { get; set; } 

        public List<CustomFieldListOption> CustomFields { get; set; } = new();

        public StandardFilter(
            bool includeInActive = false,
            bool includeDeleted = false,
            bool likeStringSearch = false,
            bool onlyParents = false)
        {
            IncludeInActive = includeInActive;
            IncludeDeleted = includeDeleted;
            LikeSearch = likeStringSearch;
            OnlyParents = onlyParents;
        }
    }

}
