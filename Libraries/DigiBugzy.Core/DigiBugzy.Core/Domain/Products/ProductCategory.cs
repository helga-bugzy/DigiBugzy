
namespace DigiBugzy.Core.Domain.Products
{
    public class ProductCategory: BaseAdministrationEntity, IBaseCategoryMappingEntity
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }
}
