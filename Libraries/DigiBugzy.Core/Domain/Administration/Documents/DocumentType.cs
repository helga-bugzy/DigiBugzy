

namespace DigiBugzy.Core.Domain.Administration.Documents
{
    [Table(name: nameof(DocumentType), Schema = DatabaseConstants.Schemas.Admin)]
    public class DocumentType: BaseAdministrationEntity
    {
        [Required]
        public int ClassificationId { get; set; }

        [Required]
        public int DefaultDocumentFileTypeId { get; set; }

        [ForeignKey(nameof(ClassificationId))]
        public Classification Classification { get; set; }

        [ForeignKey(nameof(DefaultDocumentFileTypeId))]
        public DocumentFileType DefaultDocumentFileType { get; set; }
    }
}
