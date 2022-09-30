namespace DigiBugzy.Core.Domain.Finance.Assets

{
    [Table(name: nameof(AssetDocument), Schema = DatabaseConstants.Schemas.Project)]
    public class AssetDocument : BaseDocumentEntity
    {
        [Required]
        public int AssetId { get; set; }  

        public bool IsSpecifications { get; set; }

        public bool IsInstructions { get; set; }

        public bool IsWarranty { get; set; }

        public bool IsInvoice { get; set; }

        [ForeignKey(nameof(AssetId))]
        public Asset Product { get; set; }    
    }
}
