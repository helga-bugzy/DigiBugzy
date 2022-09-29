using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Core.Helpers;
using DigiBugzy.Services.Projects;
using DigiBugzy.Services.SampleData;

namespace DigiBugzy.Desktop.Projects
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
            bsProjects.Clear();

            bsProjects.DataSource = service.Get(new StandardFilter { Name = txtFilterProjectName.Text.Trim() });
            gridProjects.DataSource = bsProjects;

            if (gvProjects.Columns[nameof(Project.Id)] != null) gvProjects.Columns[nameof(Project.Id)].Visible = false;
            if (gvProjects.Columns[nameof(Project.CreatedOn)] != null) gvProjects.Columns[nameof(Project.CreatedOn)].Visible = false;
            if (gvProjects.Columns[nameof(Project.DigiAdminId)] != null) gvProjects.Columns[nameof(Project.DigiAdminId)].Visible = false;
            if (gvProjects.Columns[nameof(Project.DigiAdmin)] != null) gvProjects.Columns[nameof(Project.DigiAdmin)].Visible = false;

            LoadGrid_ProjectSections();

            Application.DoEvents();

        }

        private void LoadGrid_ProjectSections()
        {
            _selectedProjectSection = new ProjectSection();
            _selectedProjectSectionPart = new ProjectSectionPart();
            bsSections.Clear();

            if (_selectedProject.Id <= 0)
            {
                bsSections.DataSource = new List<ProjectSection>();
            }
            else
            {
                using var service = new ProjectSectionService(Globals.GetConnectionString());
                bsSections.DataSource = service.GetByProjectId(_selectedProject.Id);
                

                if (gvProjectSections.Columns[nameof(ProjectSection.Id)] != null) gvProjectSections.Columns[nameof(ProjectSection.Id)].Visible = false;
                if (gvProjectSections.Columns[nameof(ProjectSection.ProjectId)] != null) gvProjectSections.Columns[nameof(ProjectSection.ProjectId)].Visible = false;
                if (gvProjectSections.Columns[nameof(ProjectSection.CreatedOn)] != null) gvProjectSections.Columns[nameof(ProjectSection.CreatedOn)].Visible = false;
                if (gvProjectSections.Columns[nameof(ProjectSection.DigiAdminId)] != null) gvProjectSections.Columns[nameof(ProjectSection.DigiAdminId)].Visible = false;
                if (gvProjectSections.Columns[nameof(ProjectSection.DigiAdmin)] != null) gvProjectSections.Columns[nameof(ProjectSection.DigiAdmin)].Visible = false;
            }

            gridProjectSections.DataSource = bsSections;

            LoadGrid_ProjectSectionParts();

            Application.DoEvents();

        }

        private void LoadGrid_ProjectSectionParts()
        {
            bsParts.Clear();
            if (_selectedProjectSection.Id <= 0)
            {
                bsParts.DataSource = new List<ProjectSectionPart>();
            }
            else
            {
                using var service = new ProjectSectionPartService(Globals.GetConnectionString());
                bsParts.DataSource = service.GetByProjectSectionId(_selectedProjectSection.Id);

                if (gvProjectSectionParts.Columns[nameof(ProjectSectionPart.Id)] != null) gvProjectSectionParts.Columns[nameof(ProjectSectionPart.Id)].Visible = false;
                if (gvProjectSectionParts.Columns[nameof(ProjectSectionPart.ProjectSectionId)] != null) gvProjectSectionParts.Columns[nameof(ProjectSectionPart.ProjectSectionId)].Visible = false;
                if (gvProjectSectionParts.Columns[nameof(ProjectSectionPart.CreatedOn)] != null) gvProjectSectionParts.Columns[nameof(ProjectSectionPart.CreatedOn)].Visible = false;
                if (gvProjectSectionParts.Columns[nameof(ProjectSectionPart.DigiAdminId)] != null) gvProjectSectionParts.Columns[nameof(ProjectSectionPart.DigiAdminId)].Visible = false;
                if (gvProjectSectionParts.Columns[nameof(ProjectSectionPart.DigiAdmin)] != null) gvProjectSectionParts.Columns[nameof(ProjectSectionPart.DigiAdmin)].Visible = false;
            }

            gridProjectSectionParts.DataSource = bsParts;
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
               
            }
            else
            {
                imgProjectPhoto.Image = ImageHelpers.GetImageFromByteArray(_selectedProject.CoverImage);
            }
            
            tabProjectEditors.Show();
            

            //documents

            //products

            LoadGrid_ProjectSections();

            Application.DoEvents();
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
            }
            else
            {
                imgSectionPhoto.Image = ImageHelpers.GetImageFromByteArray(_selectedProjectSection.CoverImage);
            }
            
            tabPartsEditors.Show();

            //documents

            //products

            LoadGrid_ProjectSectionParts();

            //docs,
            //products

            Application.DoEvents();

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
            }
            else
            {
                imgPartPhoto.Image = ImageHelpers.GetImageFromByteArray(_selectedProjectSectionPart.CoverImage);
            }

            
            tabSectionEditors.Show();

            //documents

            //products

            LoadGrid_ProjectSectionParts();

            //docs,
            //products

            Application.DoEvents();

        }

        #endregion

        #region Saving

        private void SaveProject()
        {
            _selectedProject.Name = txtProject_Name.Text;
            _selectedProject.Description = txtProjectDescription.Text;
            _selectedProject.IsActive = chkProjectActive.Checked;


            if (imgProjectPhoto.Image != null)
            {
                _selectedProject.CoverImage = ImageHelpers.CopyImageToByteArray(imgProjectPhoto.Image);
            }

            using var service = new ProjectService(Globals.GetConnectionString());
            if (_selectedProject.Id > 0)
            {
                service.Update(_selectedProject);
            }
            else
            {
                _selectedProject.DigiAdminId = Globals.DigiAdministration.Id;
                _selectedProject.IsDeleted = false;
                _selectedProject.CreatedOn = DateTime.Now;
                _selectedProject.Id = service.Create(_selectedProject);
            }

            LoadGrid_Projects();

        }

        private void SaveProjectSection()
        {
            _selectedProjectSection.Name = txtSectionName.Text;
            _selectedProjectSection.Description = txtSectionDescription.Text;
            _selectedProjectSection.IsActive = chkSectionActive.Checked;


            if (imgSectionPhoto.Image != null)
            {
                _selectedProjectSection.CoverImage = ImageHelpers.CopyImageToByteArray(imgSectionPhoto.Image);
            }

            using var service = new ProjectSectionService(Globals.GetConnectionString());
            if (_selectedProjectSection.Id > 0)
            {
                service.Update(_selectedProjectSection);
            }
            else
            {
                _selectedProjectSection.DigiAdminId = Globals.DigiAdministration.Id;
                _selectedProjectSection.IsDeleted = false;
                _selectedProjectSection.CreatedOn = DateTime.Now;
                _selectedProjectSection.Id = service.Create(_selectedProjectSection);
            }

            LoadGrid_ProjectSections();

        }

        private void SaveProjectSectionPart()
        {
            _selectedProjectSectionPart.Name = txtPartName.Text;
            _selectedProjectSectionPart.Description = txtPartDescription.Text;
            _selectedProjectSectionPart.IsActive = chkPartActive.Checked;


            if (imgPartPhoto.Image != null)
            {
                _selectedProjectSectionPart.CoverImage = ImageHelpers.CopyImageToByteArray(imgPartPhoto.Image);
            }

            using var service = new ProjectSectionPartService(Globals.GetConnectionString());
            if (_selectedProjectSectionPart.Id > 0)
            {
                service.Update(_selectedProjectSectionPart);
            }
            else
            {
                _selectedProjectSectionPart.DigiAdminId = Globals.DigiAdministration.Id;
                _selectedProjectSectionPart.IsDeleted = false;
                _selectedProjectSectionPart.CreatedOn = DateTime.Now;
                _selectedProjectSectionPart.Id = service.Create(_selectedProjectSectionPart);
            }

            LoadSelected_ProjectSectionPart();

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

        #region Grid - Projects

       

        private void bsProjects_PositionChanged(object sender, EventArgs e)
        {
            if (sender is not BindingSource) return;

            if (BindingContext[bsProjects].Position <= -1) return;
            _selectedProject = (Project)bsProjects.Current;
            LoadSelected_Project();

        }

        private void bsSections_PositionChanged(object sender, EventArgs e)
        {
            if (sender is not BindingSource) return;

            if (BindingContext[bsSections].Position <= -1) return;
            _selectedProjectSection = (ProjectSection)bsSections.Current;
            LoadSelected_ProjectSection();

        }

        private void bsParts_PositionChanged(object sender, EventArgs e)
        {
            if (sender is not BindingSource) return;

            if (BindingContext[bsParts].Position <= -1) return;
            _selectedProjectSectionPart = (ProjectSectionPart)bsParts.Current;
            LoadSelected_ProjectSectionPart();

        }

        #endregion



        #region Grid: Sections

       
        #endregion


        #region Grid: Parts


        #endregion



        #endregion

        #region Projects

        #region Editor

        private void btnProjectAddNew_Click(object sender, EventArgs e)
        {
            _selectedProject = new Project();
            LoadSelected_Project();
        }

        private void btnProjectImage_Click(object sender, EventArgs e)
        {
            if (dlgProjectImage.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(dlgProjectImage.FileName)) return;

            lblProjectSelectedFileName.Text = dlgProjectImage.FileName;
            imgProjectPhoto.Image = ImageHelpers.ResizeImage(new Bitmap(dlgProjectImage.FileName),
                Globals.Settings.ProductSettings!.ImageWidth, Globals.Settings.ProductSettings.ImageHeight);
            imgProjectPhoto.Visible = true;
        }

        private void btnProjectRestore_Click(object sender, EventArgs e)
        {
            if (_selectedProject.Id <= 0) return;

            _selectedProject.IsDeleted = false;
            _selectedProject.IsActive = true;

            using var service = new ProjectService(Globals.GetConnectionString());
            service.Update(_selectedProject);

            LoadGrid_Projects();
        }

        private void btnProjectSave_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void btnProjectDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProject.Id <= 0) return;
            var service = new ProjectService(Globals.GetConnectionString());
            service.Delete(_selectedProject.Id, false);
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


        #endregion

        #endregion
        
        #region Sections

        #region Editor

        private void btnSectionAddNew_Click(object sender, EventArgs e)
        {
            _selectedProjectSection = new ProjectSection();
            LoadSelected_ProjectSection();
        }


        private void btnSectionvImage_Click(object sender, EventArgs e)
        {
            if (dlgProjectSectionPhoto.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(dlgProjectSectionPhoto.FileName)) return;

            lblSectionSelectedFileName.Text = dlgProjectSectionPhoto.FileName;
            imgSectionPhoto.Image = ImageHelpers.ResizeImage(new Bitmap(dlgProjectSectionPhoto.FileName),
                Globals.Settings.ProductSettings!.ImageWidth, Globals.Settings.ProductSettings.ImageHeight);
            imgSectionPhoto.Visible = true;
        }

        private void btnSectionSave_Click(object sender, EventArgs e)
        {
            SaveProjectSection();
        }

        private void btnSectionRestore_Click(object sender, EventArgs e)
        {
            if (_selectedProjectSection.Id <= 0) return;

            _selectedProjectSection.IsDeleted = false;
            _selectedProjectSection.IsActive = true;

            using var service = new ProjectSectionService(Globals.GetConnectionString());
            service.Update(_selectedProjectSection);

            LoadGrid_ProjectSections();
        }

        private void btnSectionDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProjectSection.Id <= 0) return;
            var service = new ProjectSectionService(Globals.GetConnectionString());
            service.Delete(_selectedProjectSection.Id, false);
            LoadGrid_ProjectSections();
            Application.DoEvents();
        }

        #endregion

        #endregion

        #region Parts

        #region Editor

        private void btnPartAddNew_Click(object sender, EventArgs e)
        {
            _selectedProjectSectionPart = new ProjectSectionPart();
            LoadSelected_ProjectSectionPart();
        }

        private void btnPartImage_Click(object sender, EventArgs e)
        {
            if (dlgProjectSectionPartPhoto.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(dlgProjectSectionPartPhoto.FileName)) return;

            lblPartSelectedFileName.Text = dlgProjectSectionPartPhoto.FileName;
            imgPartPhoto.Image = ImageHelpers.ResizeImage(new Bitmap(dlgProjectSectionPartPhoto.FileName),
                Globals.Settings.ProductSettings!.ImageWidth, Globals.Settings.ProductSettings.ImageHeight);
            imgPartPhoto.Visible = true;
        }

        private void btnPartRestore_Click(object sender, EventArgs e)
        {
            if (_selectedProjectSectionPart.Id <= 0) return;

            _selectedProjectSectionPart.IsDeleted = false;
            _selectedProjectSectionPart.IsActive = true;

            using var service = new ProjectSectionPartService(Globals.GetConnectionString());
            service.Update(_selectedProjectSectionPart);

            LoadGrid_ProjectSectionParts();
        }

        private void btnPartSave_Click(object sender, EventArgs e)
        {
            SaveProjectSectionPart();
        }

        private void btnPartDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProjectSectionPart.Id <= 0) return;
            var service = new ProjectSectionPartService(Globals.GetConnectionString());
            service.Delete(_selectedProjectSectionPart.Id, false);
            LoadGrid_ProjectSectionParts();
            Application.DoEvents();
        }




















        #endregion

        #endregion

        #endregion

        

        
    }
}