﻿
namespace DigiBugzy.Core.Domain.Projects
{
    [Table(name: nameof(ProjectSectionPart), Schema = DatabaseConstants.Schemas.Project)]
    public class ProjectSectionPart: BaseAdministrationEntity
    {
        public int ProjectSectionId { get; set; }

        [ForeignKey(nameof(ProjectSectionId))]
        public ProjectSection ProjectSection { get; set; }
    }
}