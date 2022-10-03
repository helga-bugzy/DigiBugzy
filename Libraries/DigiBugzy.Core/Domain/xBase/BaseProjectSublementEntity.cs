
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Core.Domain.xBase
{
    public class BaseProjectSublementEntity: BaseDocumentEntity
    {
        public int ProjectId { get; set; }

        public int? ProjectSectionId { get; set; }

        public int? ProjectSectionPartId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        [ForeignKey(nameof(ProjectSectionId))]
        public ProjectSection ProjectSection { get; set; }

        [ForeignKey(nameof(ProjectSectionPartId))]
        public ProjectSectionPart ProjectSectionPart { get; set; }
    }
}
