
namespace DigiBugzy.Core.Domain.xBase
{
    public class MappingViewModel: BaseEntity
    {
        /// <summary>
        /// Current working entity ie Category when getting Category-Customfields mappings
        /// </summary>
        public int EntityMappedFromId { get; set; }

        /// <summary>
        /// Entity relating to thus custom field when getting Category-CustomFields mappings
        /// </summary>
        public int EntityMappedToId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// If custom fields, what type of field
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// If custom fields, the custom field type id
        /// </summary>
        public int TypeId { get; set; }


        /// <summary>
        /// Indicator if this is already mapped
        /// </summary>
        public bool IsMapped { get; set; }

        /// <summary>
        /// Optional to indicate value i.e. Product CustomField Value entered
        /// </summary>
        public string CustomFieldValue { get; set; }

        /// <summary>
        /// Optional value to load i.e. Categories Treeview with mappings
        /// </summary>
        public int? ParentId { get; set; }
    }
}
