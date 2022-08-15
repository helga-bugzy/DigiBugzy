

namespace DigiBugzy.Core.Domain.Administration.Documents
{
    [Table(name: nameof(DocumentType), Schema = DatabaseConstants.Schemas.Admin)]
    public class Document : BaseAdministrationEntity
    {
        public int ClassificationId { get; set; }

        public int DocumentTypeId { get; set; }

        public string DocumentName { get; set; }

        [ForeignKey(nameof(ClassificationId))]
        public Classification Classification { get; set; }

        [ForeignKey(nameof(DocumentTypeId))]
        public DocumentType DocumentType{get;set;}
    }
}
