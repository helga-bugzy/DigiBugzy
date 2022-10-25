
namespace DigiBugzy.Core.Domain.Projects
{
    [Table(name: nameof(ProjectSectionPart), Schema = DatabaseConstants.Schemas.Project)]
    public class ProjectSectionPart: BaseAdministrationEntity
    {
        [NotMapped]
        public string ProjectName { get; set; }

        [NotMapped]
        public string ProjectSectionName { get; set; }


        public byte[] CoverImage { get; set; }

        public int ProjectSectionId { get; set; }


        [ForeignKey(nameof(ProjectSectionId))]
        public ProjectSection ProjectSection { get; set; }
    }
}
