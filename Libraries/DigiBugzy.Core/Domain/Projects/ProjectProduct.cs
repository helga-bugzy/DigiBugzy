
using DigiBugzy.Core.Domain.Products;

namespace DigiBugzy.Core.Domain.Projects
{
    [Table(name: nameof(ProjectProduct), Schema = DatabaseConstants.Schemas.Project)]
    public class ProjectProduct : BaseProjectSublementEntity
    {
        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
