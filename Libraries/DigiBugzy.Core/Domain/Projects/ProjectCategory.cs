

namespace DigiBugzy.Core.Domain.Projects
{
    [Table(name: nameof(ProjectCategory), Schema = DatabaseConstants.Schemas.Project)]
    public class ProjectCategory: BaseProjectSublementEntity
    {
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
