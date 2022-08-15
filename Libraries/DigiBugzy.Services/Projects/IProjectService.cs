

using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    public interface IProjectService
    {
        public Project GetById(int id);

        public List<Project> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete);

        public void Update(Project entity);

        public int Create(Project entity);
    }
}
