
using DigiBugzy.Core.Domain.Administration.Documents;

namespace DigiBugzy.Core.Domain.Projects
{
    public class ProjectDocument : BaseProjectSublementEntity
    {
        public int DocumentId { get; set; }


        [ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }
    }
}
