﻿
namespace DigiBugzy.Domain.Entities.Products
{
    public class ProductCategory: BaseEntity, IBaseCategoryMappingEntity
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }
}
