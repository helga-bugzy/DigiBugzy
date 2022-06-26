namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Products.Models
{
    public class ProductModel : BaseAdminsProperties
    {
        public int ParentId { get; set; }

        public int ClassificationId { get; set; }

        public Classification Classification { get; set; }

        public Product Parent { get; set; }

        public List<Product> Children { get; set; }
    }
}
