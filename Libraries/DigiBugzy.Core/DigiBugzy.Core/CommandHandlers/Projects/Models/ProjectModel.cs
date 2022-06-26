namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Projects.Models
{
    public class ProjectModel : BaseAdminsProperties
    {
        public int ParentId { get; set; }

        public int ClassificationId { get; set; }

        public Classification Classification { get; set; }

        public Project Parent { get; set; }

        public List<Project> Children { get; set; }
    }
}
