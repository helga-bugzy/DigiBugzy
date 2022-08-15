
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    public interface IProjectSectionService
    {
        #region Requests

        public ProjectSection GetById(int id);

        /// <summary>
        /// Gets list of project sections by projectid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ProjectSection> GetByProjectId(int id);

        public List<ProjectSection> Get(StandardFilter filter);

        #endregion

        #region Commands

        public void Delete(int id, bool hardDelete);

        public void Update(ProjectSection entity);

        public int Create(ProjectSection entity);
    }

    #endregion
}
