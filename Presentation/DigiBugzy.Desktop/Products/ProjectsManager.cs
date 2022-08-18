using DevExpress.XtraEditors;using System.Collections.Generic;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Core.Helpers;
using DigiBugzy.Services.Projects;
using DigiBugzy.Services.SampleData;


namespace DigiBugzy.Desktop.Products
{
    public partial class ProjectsManager : XtraForm
    {
        #region Properties

        private Project _selectedProject { get; set; } = new();

        private ProjectSection _selectedProjectSection { get; set; } = new();

        private ProjectSectionPart _selectedProjectSectionPart { get; set; } = new();

        #endregion

        #region Ctor

        public ProjectsManager()
        {
            InitializeComponent();
            LoadGrid_Projects();

            //Sample data only when in development mode
            btnSampleData.Visible = btnSampleDataDelete.Visible = Globals.ConnectionEnvironment == ConnectionEnvironment.Development;

            Application.DoEvents();
        }

        #endregion

        #region Helper Methods

        #region Load Grids

        private void LoadGrid_Projects()
        {
            using var service = new ProjectService(Globals.GetConnectionString());
            gridProjects.DataSource = service.Get(new StandardFilter { Name = txtFilterProjectName.Text.Trim() });


            LoadGrid_ProjectSections();

            Application.DoEvents();

        }

        private void LoadGrid_ProjectSections()
        {
            _selectedProjectSection = new ProjectSection();
            _selectedProjectSectionPart = new ProjectSectionPart();

            if (_selectedProject.Id <= 0)
            {
                gridProjectSections.DataSource = new List<ProjectSection>();
            }
            else
            {
                using var service = new ProjectSectionService(Globals.GetConnectionString());
                gridProjectSections.DataSource = service.GetByProjectId(_selectedProject.Id);
            }

            LoadGrid_ProjectSectionParts();

            Application.DoEvents();

        }

        private void LoadGrid_ProjectSectionParts()
        {
            if (_selectedProjectSection.Id <= 0)
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

        #endregion

        #region Load Selected Items

        private void LoadSelected_Project()
        {
            _selectedProjectSection = new ProjectSection(); ;
            _selectedProjectSectionPart = new ProjectSectionPart();

            //editor,
            txtProjectDescription.Text = _selectedProject.Description;
            txtProject_Name.Text = _selectedProject.Name;
            chkProjectActive.Checked = _selectedProject.IsActive;
            btnProjectAddNew.Visible = _selectedProject.Id > 0;
            btnProjectDelete.Visible = !_selectedProject.IsDeleted;
            btnProjectRestore.Visible = _selectedProject.IsDeleted;
            if (_selectedProject.CoverImage is not { Length: > 0 })
            {
                imgProjectPhoto.Visible = false;
                lblProjectSelectedFileName.Text = string.Empty;
                return;
            }

            imgProjectPhoto.Image = ImageHelpers.GetImageFromByteArray(_selectedProject.CoverImage);

            //documents

            //products

            LoadGrid_ProjectSections();
        }

        private void LoadSelected_ProjectSection()
        {
            _selectedProjectSectionPart = new ProjectSectionPart();

            //editor,
            txtSectionDescription.Text = _selectedProjectSection.Description;
            txtSectionName.Text = _selectedProjectSection.Name;
            chkSectionActive.Checked = _selectedProjectSection.IsActive;
            btnSectionAddNew.Visible = _selectedProjectSection.Id > 0;
            btnSectionDelete.Visible = !_selectedProjectSection.IsDeleted;
            btnSectionRestore.Visible = _selectedProjectSection.IsDeleted;
            if (_selectedProjectSection.CoverImage is not { Length: > 0 })
            {
                imgSectionPhoto.Visible = false;
                lblSectionSelectedFileName.Text = string.Empty;
                return;
            }

            imgSectionPhoto.Image = ImageHelpers.GetImageFromByteArray(_selectedProjectSection.CoverImage);

            //documents

            //products

            LoadGrid_ProjectSectionParts();

            //docs,
            //products

        }

        private void LoadSelected_ProjectSectionPart()
        {
            //editor,
            txtPartDescription.Text = _selectedProjectSectionPart.Description;
            txtPartName.Text = _selectedProjectSectionPart.Name;
            chkPartActive.Checked = _selectedProjectSectionPart.IsActive;
            btnPartAddNew.Visible = _selectedProjectSectionPart.Id > 0;
            btnPartDelete.Visible = !_selectedProjectSectionPart.IsDeleted;
            btnPartRestore.Visible = _selectedProjectSectionPart.IsDeleted;
            if (_selectedProjectSectionPart.CoverImage is not { Length: > 0 })
            {
                imgPartPhoto.Visible = false;
                lblPartSelectedFileName.Text = string.Empty;
                return;
            }

            imgPartPhoto.Image = ImageHelpers.GetImageFromByteArray(_selectedProjectSectionPart.CoverImage);

            //documents

            //products

            LoadGrid_ProjectSectionParts();

            //docs,
            //products

        }

        #endregion

        #endregion

        #region Control Event Procedures

        #region Filter 

        private void butProjectsFilter_Click(object sender, EventArgs e)
        {
            LoadGrid_Projects();
        }

        private void btnProjectsSectionsFilter_Click(object sender, EventArgs e)
        {
            LoadGrid_ProjectSections();
        }

        private void butProjectsSectionPartsFilter_Click(object sender, EventArgs e)
        {
            LoadGrid_ProjectSectionParts();
        }


        #endregion


        #region Grid Controls

        private void gvProjects_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                _selectedProject = (Project)gvProjects.GetRow(e.FocusedRowHandle);
                LoadSelected_Project();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void gvProjectSections_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (_selectedProject.Id <= 0) _selectedProjectSection = new ProjectSection();
                else _selectedProjectSection = (ProjectSection)gvProjectSections.GetRow(e.FocusedRowHandle);
                LoadSelected_ProjectSection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void gvProjectSectionParts_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {

                if (_selectedProject.Id <= 0)
                {
                    _selectedProjectSection = new ProjectSection();
                    _selectedProjectSectionPart = new ProjectSectionPart();
                }
                else if (_selectedProjectSection.Id <= 0)
                {
                    _selectedProjectSectionPart = new ProjectSectionPart();
                }
                else
                {
                    _selectedProjectSection = (ProjectSection)gvProjectSections.GetRow(e.FocusedRowHandle);
                }

                LoadSelected_ProjectSectionPart();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        #endregion

        #endregion

        private void btnSampleData_Click(object sender, EventArgs e)
        {
            using var service = new SampleDataService(
                connectionString: Globals.GetConnectionString(),
                sampleDataType: SampleDataTypeEnum.Projects,
                classificationId: (int)ClassificationsEnum.Project,
                digiAdminId: Globals.DigiAdministration.Id);
            service.CreateSampleData();

            _selectedProject = new Project();
            _selectedProjectSection = new ProjectSection();
            _selectedProjectSectionPart = new ProjectSectionPart();


            LoadGrid_Projects();

            Application.DoEvents();
        }

        private void btnSampleDataDelete_Click(object sender, EventArgs e)
        {
            using var service = new SampleDataService(
                connectionString: Globals.GetConnectionString(),
                sampleDataType: SampleDataTypeEnum.Projects,
                classificationId: (int)ClassificationsEnum.Project,
                digiAdminId: Globals.DigiAdministration.Id);
            service.DeleteSampleData();

            using var productService = new ProductService(Globals.GetConnectionString());
            var collection = productService.Get(new StandardFilter { Name = "Sample", LikeSearch = true });
            foreach (var item in collection)
            {
                productService.Delete(item.Id, true);
            }

            _selectedProject = new Project();
            _selectedProjectSection = new ProjectSection();
            _selectedProjectSectionPart = new ProjectSectionPart();

            LoadGrid_Projects();

            Application.DoEvents();
        }

      
    }
}