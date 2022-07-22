



namespace DigiBugzy.Core.Domain.xBase.Interfaces
{
    public interface IBaseCategoryMappingEntity
    {
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
