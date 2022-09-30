namespace DigiBugzy.Core.Domain.Projects
{
    [Table(name: nameof(ProjectDocument), Schema = DatabaseConstants.Schemas.Project)]
    public class ProjectDocument : BaseProjectSublementEntity
    {
        public bool Is3DPrintingDocument { get; set; }

        public bool IsSpecifications { get; set; }

        public bool IsPlans { get; set; }

        public bool IsInstructions { get; set; }
    }
}
