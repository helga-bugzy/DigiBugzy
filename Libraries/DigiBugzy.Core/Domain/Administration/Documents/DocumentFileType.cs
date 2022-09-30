

namespace DigiBugzy.Core.Domain.Administration.Documents
{
    [Table(name: nameof(DocumentFileType), Schema = DatabaseConstants.Schemas.Admin)]
    public class DocumentFileType: BaseAdministrationEntity
    {
        [MaxLength(10), MinLength(1)]
        [Required]
        public string Extension { get; set; }
    }
}
