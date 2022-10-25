using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Services.Projects
{
    public interface IProjectDocumentService
    {
        #region Requests

        public ProjectDocument GetById(int id);

        public List<ProjectDocument> Get(ProjectDocumentFilter filter);


        #endregion

        #region Commands


        public void Delete(int id, bool hardDelete);

        public void Delete(ProjectDocument entity, bool hardDelete);

        public void Update(ProjectDocument entity);

        public int Create(ProjectDocument entity);

        #endregion
    }
}
