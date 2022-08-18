

namespace DigiBugzy.Core.Domain.Projects
{
    [Table(name: nameof(ProjectSection), Schema = DatabaseConstants.Schemas.Project)]
    public class ProjectSection: BaseAdministrationEntity
    {
        public byte[] CoverImage { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
    }
}
