using DevExpress.XtraEditors;using System.Collections.Generic;
using System.Drawing;
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
            tabProject.Show();
            

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
                return;
            }

            imgSectionPhoto.Image = ImageHelpers.GetImageFromByteArray(_selectedProjectSection.CoverImage);
            tabSections.Show();

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
                return;
            }

            imgPartPhoto.Image = ImageHelpers.GetImageFromByteArray(_selectedProjectSectionPart.CoverImage);
            tabProjectSectionParts.Show();

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
                if(_selectedProjectSection == null)_selectedProjectSection = new ProjectSection();
                if(_selectedProjectSectionPart == null) _selectedProjectSectionPart = new ProjectSectionPart();

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