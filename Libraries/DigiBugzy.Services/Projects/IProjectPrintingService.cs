using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Data.Common.xBaseObjects;

namespace DigiBugzy.Services.Projects
{
    public interface IProjectPrintingService
    {
        #region Requests

        public ProjectPrinting GetById(int id);

        public List<ProjectPrinting> Get(ProjectPrintingFilter filter);


        #endregion

        #region Commands


        public void Delete(int id, bool hardDelete);

        public void Delete(ProjectPrinting entity, bool hardDelete);

        public void Update(ProjectPrinting entity);

        public int Create(ProjectPrinting entity);

        #endregion
    }
}
