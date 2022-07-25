

namespace DigiBugzy.Core.Domain.Administration.Categories
{
    [Table(name: nameof(Category), Schema = DatabaseConstants.Schemas.Admin)]
    public class Category: BaseAdministrationEntity
    {
        public int ClassificationId { get; set; }

        public int? ParentId { get; set; }


        [ForeignKey(nameof(ClassificationId))]
        public Classification Classification { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Category Parent { get; set; }

        /// <summary>
        /// List of mapped custom fields
        /// </summary>
        public List<CategoryCustomField> CustomFieldMappings { get; set; }

    }
}
