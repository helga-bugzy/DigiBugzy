using DigiBugzy.Core.Domain.Finance.Assets;

namespace DigiBugzy.Core.Domain.BusinessEntities

{
    [Table(name: nameof(BusinessEntityDocument), Schema = DatabaseConstants.Schemas.Project)]
    public class BusinessEntityDocument : BaseDocumentEntity
    {
        [Required]
        public int BusinessEntityId { get; set; }  

       
        [ForeignKey(nameof(BusinessEntityId))]
        public BusinessEntity BusinessEntity { get; set; }    
    }
}

