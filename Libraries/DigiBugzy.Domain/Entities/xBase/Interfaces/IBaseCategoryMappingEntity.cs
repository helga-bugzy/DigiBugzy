

namespace DigiBugzy.Domain.Entities.xBase.Interfaces
{
    public interface IBaseCategoryMappingEntity
    {
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
