
using DigiBugzy.Core.Domain.Administration.Documents;

namespace DigiBugzy.Core.Domain.Projects
{
    [Table(name: nameof(ProjectDocument), Schema = DatabaseConstants.Schemas.Project)]
    public class ProjectDocument : BaseProjectSublementEntity
    {
        public int DocumentId { get; set; }


        [ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }
    }
}
