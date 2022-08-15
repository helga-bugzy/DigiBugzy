
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    public interface IProjectSectionPartService
    {
        #region Requests

        public ProjectSectionPart GetById(int id);

        /// <summary>
        /// Gets list of section parts for a specific section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ProjectSectionPart> GetByProjectSectionId(int id);

        public List<ProjectSectionPart> Get(StandardFilter filter);

        #endregion

        #region Commands


        public void Delete(int id, bool hardDelete);

        public void Update(ProjectSectionPart entity);

        public int Create(ProjectSectionPart entity);

        #endregion
    }
}
