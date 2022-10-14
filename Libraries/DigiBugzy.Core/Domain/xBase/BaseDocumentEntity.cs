using DigiBugzy.Core.Domain.Administration.Documents;

namespace DigiBugzy.Core.Domain.xBase
{
    [Table(name: nameof(DocumentType), Schema = DatabaseConstants.Schemas.Admin)]
    public class BaseDocumentEntity : BaseAdministrationEntity
    {
        public byte[] DocumentData { get; set; }

        public int DocumentTypeId { get; set; }

        public int DocumentFileTypeId { get; set; }

        
        [ForeignKey(nameof(DocumentTypeId))]
        public DocumentType DocumentType { get; set; }

        [ForeignKey(nameof(DocumentFileTypeId))]
        public DocumentFileType DocumentFileType { get; set; }  




    }
}
