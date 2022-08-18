using DevExpress.XtraEditors;
using System.Collections.Generic;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Services.Projects;


namespace DigiBugzy.Desktop.Products
{
    public partial class ProjectsManager : XtraForm
    {
        #region Properties

        private Project? _selectedProject;

        private ProjectSection? _selectedProjectSection;

        private ProjectSectionPart? _selectedProjectSectionPart;

        #endregion

        #region Ctor

        public ProjectsManager()
        {
            InitializeComponent();
            LoadProjects();

            Application.DoEvents();
        }

        #endregion

        #region Helper Methods

        private void LoadProjects()
        {
            using var service = new ProjectService(Globals.GetConnectionString());
            gridProjects.DataSource = service.Get(new StandardFilter { Name = txtFilterProjectName.Text.Trim() });

            _selectedProject = null;
            _selectedProjectSection = null;
            _selectedProjectSectionPart = null;

            LoadProjectSections();

            Application.DoEvents();

        }

        private void LoadProjectSections()
        {
            _selectedProjectSection = null;
            _selectedProjectSectionPart = null;

            if (_selectedProject == null)
            {
                gridProjectSections.DataSource = new List<ProjectSection>();
            }
            else
            {
                using var service = new ProjectSectionService(Globals.GetConnectionString());
                gridProjectSections.DataSource = service.GetByProjectId(_selectedProject.Id);
            }

            LoadProjectSectionParts();

            Application.DoEvents();
            
        }

        private void LoadProjectSectionParts()
        {
            _selectedProjectSectionPart = null;
            if (_selectedProjectSection == null)
            {
                gridProjectSectionParts.DataSource = new List<ProjectSectionPart>();
            }
            else
            {
                using var service = new ProjectSectionPartService(Globals.GetConnectionString());
                gridProjectSectionParts.DataSource = service.GetByProjectSectionId(_selectedProjectSection.Id);
            }

            Application.DoEvents();
        }

        private void LoadSelectedProject()
        {
            _selectedProjectSection = null;
            _selectedProjectSectionPart = null;
            //editor,
            //documents
            //products
            LoadProjectSections();
        }

        private void LoadSelectedProjectSection()
        {
            //editor
            //docs,
            //products
            _selectedProjectSectionPart = null;
            LoadProjectSectionParts();
        }

        private void LoadSelectedProjectSectionPart()
        {
            //editor
            //docs,
            //products
        }

        #endregion

        #region Control Event Procedures

        private void butProjectsFilter_Click(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void btnProjectsSectionsFilter_Click(object sender, EventArgs e)
        {
            LoadProjectSections();
        }

        private void butProjectsSectionPartsFilter_Click(object sender, EventArgs e)
        {
            LoadProjectSectionParts();
        }

        #endregion

        private void gvProjects_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _selectedProject = (Project)gvProjects.GetRow(e.RowHandle);
            
        }
    }
}