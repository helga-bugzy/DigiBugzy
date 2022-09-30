namespace DigiBugzy.Core.Domain.Products

{
    [Table(name: nameof(ProductDocument), Schema = DatabaseConstants.Schemas.Project)]
    public class ProductDocument : BaseDocumentEntity
    {
        [Required]
        public int ProductId { get; set; }  

        public bool IsSpecifications { get; set; }

        public bool IsInstructions { get; set; }

        public bool IsWarranty { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }    
    }
}
