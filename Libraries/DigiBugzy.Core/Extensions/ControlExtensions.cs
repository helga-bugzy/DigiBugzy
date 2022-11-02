
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraWaitForm;
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Core.Extensions
{
    public static class ControlExtensions
    {
        #region DevExpress Grid & GridView

        /// <summary>
        /// Hide base entity columns such as digiadmin created on etc
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="hideId"></param>
        public static void HideAdminColumns(this GridView gridView, bool hideId = true)
        {
            if (gridView.Columns[nameof(BaseEntity.CreatedOn)] != null)
                gridView.Columns[nameof(BaseEntity.CreatedOn)].Visible = false;

            if (gridView.Columns[nameof(BaseEntity.DigiAdmin)] != null)
                gridView.Columns[nameof(BaseEntity.DigiAdmin)].Visible = false;

            if (gridView.Columns[nameof(BaseEntity.DigiAdminId)] != null)
                gridView.Columns[nameof(BaseEntity.DigiAdminId)].Visible = false;

            if (gridView.Columns[nameof(BaseEntity.IsActive)] != null)
                gridView.Columns[nameof(BaseEntity.IsActive)].Visible = false;

            if (gridView.Columns[nameof(BaseEntity.IsDeleted)] != null)
                gridView.Columns[nameof(BaseEntity.IsDeleted)].Visible = false;

            if (gridView.Columns["ParentId"] != null)
                gridView.Columns["ParentId"].Visible = false;

            if (gridView.Columns["ParentName"] != null)
                gridView.Columns["ParentName"].Visible = false;

            if (!hideId) return;
            if (gridView.Columns[nameof(BaseEntity.Id)] != null)
                gridView.Columns[nameof(BaseEntity.Id)].Visible = false;



        }

        /// <summary>
        /// Hide project related information i.e. projectid, project, projectsectionid, etc...
        /// </summary>
        /// <param name="gridView"></param>
        public static void HideProjectIdColumns(this GridView gridView)
        {
            if (gridView.Columns[nameof(ProjectDocument.ProjectId)] != null)
                gridView.Columns[nameof(ProjectDocument.ProjectId)].Visible = false;
            if (gridView.Columns[nameof(ProjectDocument.Project)] != null)
                gridView.Columns[nameof(ProjectDocument.Project)].Visible = false;

            if (gridView.Columns[nameof(ProjectDocument.ProjectSectionId)] != null)
                gridView.Columns[nameof(ProjectDocument.ProjectSectionId)].Visible = false;
            if (gridView.Columns[nameof(ProjectDocument.ProjectSection)] != null)
                gridView.Columns[nameof(ProjectDocument.ProjectSection)].Visible = false;

            if (gridView.Columns[nameof(ProjectDocument.ProjectSectionPartId)] != null)
                gridView.Columns[nameof(ProjectDocument.ProjectSectionPartId)].Visible = false;
            if (gridView.Columns[nameof(ProjectDocument.ProjectSectionPart)] != null)
                gridView.Columns[nameof(ProjectDocument.ProjectSectionPart)].Visible = false;
        }

       

        

        #endregion

       
    }
}
