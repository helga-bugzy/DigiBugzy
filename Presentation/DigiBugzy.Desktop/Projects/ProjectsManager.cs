using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Core.Helpers;
using DigiBugzy.Data.Common.xBaseObjects;
using DigiBugzy.Services.Projects;
using DigiBugzy.Services.SampleData;

namespace DigiBugzy.Desktop.Projects
{
    public partial class ProjectsManager : XtraForm
    {
        #region Properties

        private Project SelectedProject { get; set; } = new();

        private ProjectSection SelectedProjectSection { get; set; } = new();

        private ProjectSectionPart SelectedProjectSectionPart { get; set; } = new();

        private ProjectDocumentFilter Filter { get; set; } = new();

        private bool InProjectSelection { get; set; }

        private bool InProjectSectionSelection { get; set; }

        private bool InProjectSectionPartSelection { get; set; }

        private bool _hasSelectedProjectImage = false;

        private bool _hasSelectedProjectSectionImage = false;

        private bool _hasSelectedProjectSectionPartImage = false;

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

            HideStandardGridColumns(gvProjects);

            LoadGrid_ProjectSections();

            Application.DoEvents();

        }

        private void LoadGrid_ProjectSections()
        {
            SelectedProjectSection = new ProjectSection();
            SelectedProjectSectionPart = new ProjectSectionPart();
            bsSections.Clear();

            if (SelectedProject.Id <= 0)
            {
                bsSections.DataSource = new List<ProjectSection>();
            }
            else
            {
                using var service = new ProjectSectionService(Globals.GetConnectionString());
                bsSections.DataSource = service.GetByProjectId(SelectedProject.Id);

            }

            gridProjectSections.DataSource = bsSections;

            LoadGrid_ProjectSectionParts();

            HideStandardGridColumns(gvProjectSections);

            Application.DoEvents();

        }

        private void LoadGrid_ProjectSectionParts()
        {
            bsParts.Clear();
            if (SelectedProjectSection.Id <= 0)
            {
                bsParts.DataSource = new List<ProjectSectionPart>();
            }
            else
            {
                using var service = new ProjectSectionPartService(Globals.GetConnectionString());
                bsParts.DataSource = service.GetByProjectSectionId(SelectedProjectSection.Id);
            }

            gridProjectSectionParts.DataSource = bsParts;

            HideStandardGridColumns(gvProjectSectionParts);

            Application.DoEvents();
        }

        #endregion

        #region Load Selected Items

        private void LoadSelected_Project()
        {

            switch (SelectedProject.Id)
            {
                //case > 0 when SelectedProject.Id == SelectedProject.Id:
                //    return;
                case 0:
                    SelectedProject = new Project();
                    break;
                default:
                {
                    using var service = new ProjectService(Globals.GetConnectionString());
                    SelectedProject = service.GetById(SelectedProject.Id);
                    break;
                }
            }

           LoadEditor_Project();
           LoadDocManager_Project();
            Load3DPrinting_Project();
        }

        private void LoadEditor_Project()
        {
            
            if (SelectedProject.Id <= 0)
            {
                
                //lblProjectSelectedFileName.Text = txtProject_Name.Text = txtProjectDescription.Text = string.Empty;
                btnProjectDelete.Visible = btnProjectRestore.Visible = false;
                chkProjectActive.Checked = true;

                imgProjectPhoto.Visible = false;

                dlgProjectImage.FileName = null;
                _hasSelectedProjectImage = false;
            }
            else
            {

                btnProjectDelete.Visible = !SelectedProject.IsDeleted;
                btnProjectRestore.Visible = SelectedProject.IsDeleted;

                chkProjectActive.Checked = SelectedProject.IsActive;
                txtProject_Name.Text = SelectedProject.Name;
                txtProjectDescription.Text = SelectedProject.Description;

                if (SelectedProject.CoverImage is not { Length: > 0 })
                {
                    imgProjectPhoto.Visible = false;
                    lblProjectSelectedFileName.Text = string.Empty;
                    return;
                }

                imgProjectPhoto.Image = ImageHelpers.GetImageFromByteArray(SelectedProject.CoverImage);
                imgProjectPhoto.Visible = true;
            }
            
        }

        private void LoadDocManager_Project()
        {
            var filter = new ProjectDocumentFilter
            {
                Project = SelectedProject,
                ProjectId = SelectedProject.Id,
                
                Section = new ProjectSection(),
                ProjectSectionId = 0,

                Part = new ProjectSectionPart(),
                ProjectSectionPartId = 0
            };

           // dmProject?.LoadData(type: ProjectControlEnum.Project, filter: filter);
        }

        private void Load3DPrinting_Project()
        {
            var filter = new ProjectPrintingFilter
            {
                Project = SelectedProject,
                ProjectId = SelectedProject.Id,

                Section = new ProjectSection(),
                ProjectSectionId = 0,

                Part = new ProjectSectionPart(),
                ProjectSectionPartId = 0
            };
            ucProjectPrinting1.InitializeData(ProjectControlEnum.Project, filter);
        }

        private void LoadSelected_ProjectSection()
        {

            switch (SelectedProjectSection.Id)
            {
                
                case 0:
                    SelectedProjectSection = new ProjectSection();
                    break;
                default:
                {
                    using var service = new ProjectSectionService(Globals.GetConnectionString());
                    SelectedProjectSection = service.GetById(SelectedProjectSection.Id);
                    break;
                }
            }
            LoadEditor_ProjectSection();
            LoadDocManager_ProjectSection();

        }

        private void LoadEditor_ProjectSection()
        {
            if (SelectedProjectSection.Id <= 0)
            {
                lblSectionSelectedFileName.Text = txtSectionName.Text = txtSectionDescription.Text =  string.Empty;
                btnSectionDelete.Visible = btnSectionRestore.Visible = false;
                chkSectionActive.Checked = true;

                imgSectionPhoto.Visible = false;

                dlgProjectSectionPhoto.FileName = null;
                _hasSelectedProjectSectionImage = false;
            }
            else
            {
                btnSectionDelete.Visible = !SelectedProjectSection.IsDeleted;
                btnSectionRestore.Visible = SelectedProjectSection.IsDeleted;

                chkSectionActive.Checked = SelectedProjectSection.IsActive;
                txtSectionName.Text = SelectedProjectSection.Name;
                txtSectionDescription.Text = SelectedProjectSection.Description;

                if (SelectedProjectSection.CoverImage is not { Length: > 0 })
                {
                    imgSectionPhoto.Visible = false;
                    lblSectionSelectedFileName.Text = string.Empty;
                    return;
                }

                imgSectionPhoto.Image = ImageHelpers.GetImageFromByteArray(SelectedProjectSection.CoverImage);
                imgSectionPhoto.Visible = true;
            }
        }

        private void LoadDocManager_ProjectSection()
        {
            var filter = new ProjectDocumentFilter
            {
                Project = SelectedProject,
                ProjectId = SelectedProject.Id,

                Section = SelectedProjectSection,
                ProjectSectionId = SelectedProjectSection.Id,

                Part = new ProjectSectionPart(),
                ProjectSectionPartId = 0
            };

          //  dmProjectSection?.LoadData(type: ProjectControlEnum.ProjectSection, filter: filter);
        }

        private void LoadSelected_ProjectSectionPart()
        {
            switch (SelectedProjectSectionPart.Id)
            {
                //case > 0 when SelectedProjectSectionPart.Id == SelectedProjectSectionPart.Id:
                //    return;
                case 0:
                    SelectedProjectSectionPart = new ProjectSectionPart();
                    break;
                default:
                {
                    using var service = new ProjectSectionPartService(Globals.GetConnectionString());
                    SelectedProjectSectionPart = service.GetById(SelectedProjectSectionPart.Id);
                    break;
                }
            }

            LoadEditor_ProjectSectionPart();
            LoadDocManager_ProjectSectionPart();
        }

        private void LoadEditor_ProjectSectionPart()
        {
            if (SelectedProjectSectionPart.Id <= 0)
            {

                lblPartSelectedFileName.Text = txtPartName.Text = txtPartDescription.Text = string.Empty;
                btnPartDelete.Visible = btnPartRestore.Visible = false;
                chkPartActive.Checked = true;

                imgPartPhoto.Visible = false;

                dlgProjectSectionPartPhoto.FileName = null;
                _hasSelectedProjectSectionPartImage = false;
            }
            else
            {
                btnPartDelete.Visible = !SelectedProjectSectionPart.IsDeleted;
                btnPartRestore.Visible = SelectedProjectSectionPart.IsDeleted;

                chkPartActive.Checked = SelectedProjectSectionPart.IsActive;
                txtPartName.Text = SelectedProjectSectionPart.Name;
                txtPartDescription.Text = SelectedProjectSectionPart.Description;

                if (SelectedProjectSectionPart.CoverImage is not { Length: > 0 })
                {
                    imgPartPhoto.Visible = false;
                    lblPartSelectedFileName.Text = string.Empty;
                    return;
                }

                imgPartPhoto.Image = ImageHelpers.GetImageFromByteArray(SelectedProjectSectionPart.CoverImage);
                imgPartPhoto.Visible = true;
            }

            LoadGrid_ProjectSectionParts();


        }

        private void LoadDocManager_ProjectSectionPart()
        {
            var filter = new ProjectDocumentFilter
            {
                Project = SelectedProject,
                ProjectId = SelectedProject.Id,

                Section = SelectedProjectSection,
                ProjectSectionId = SelectedProjectSection.Id,

                Part = SelectedProjectSectionPart,
                ProjectSectionPartId = SelectedProjectSectionPart.Id
            };

          //  dmProjectSectionPart?.LoadData(type: ProjectControlEnum.ProjectSectionPart, filter: filter);
        }

        #endregion

        #region Saving

        private void SaveProject()
        {
            SelectedProject.Name = txtProject_Name.Text;
            SelectedProject.Description = txtProjectDescription.Text;
            SelectedProject.IsActive = chkProjectActive.Checked;


            if (imgProjectPhoto.Image != null)
            {
                SelectedProject.CoverImage = ImageHelpers.CopyImageToByteArray(imgProjectPhoto.Image);
            }

            using var service = new ProjectService(Globals.GetConnectionString());
            if (SelectedProject.Id > 0)
            {
                service.Update(SelectedProject);
            }
            else
            {
                SelectedProject.DigiAdminId = Globals.DigiAdministration.Id;
                SelectedProject.IsDeleted = false;
                SelectedProject.CreatedOn = DateTime.Now;
                SelectedProject.Id = service.Create(SelectedProject);
            }

            LoadGrid_Projects();

        }

        private void SaveProjectSection()
        {
            SelectedProjectSection.Name = txtSectionName.Text;
            SelectedProjectSection.Description = txtSectionDescription.Text;
            SelectedProjectSection.IsActive = chkSectionActive.Checked;


            if (imgSectionPhoto.Image != null)
            {
                SelectedProjectSection.CoverImage = ImageHelpers.CopyImageToByteArray(imgSectionPhoto.Image);
            }

            using var service = new ProjectSectionService(Globals.GetConnectionString());
            if (SelectedProjectSection.Id > 0)
            {
                service.Update(SelectedProjectSection);
            }
            else
            {
                SelectedProjectSection.DigiAdminId = Globals.DigiAdministration.Id;
                SelectedProjectSection.IsDeleted = false;
                SelectedProjectSection.CreatedOn = DateTime.Now;
                SelectedProjectSection.Id = service.Create(SelectedProjectSection);
            }

            LoadGrid_ProjectSections();

        }

        private void SaveProjectSectionPart()
        {
            SelectedProjectSectionPart.Name = txtPartName.Text;
            SelectedProjectSectionPart.Description = txtPartDescription.Text;
            SelectedProjectSectionPart.IsActive = chkPartActive.Checked;


            if (imgPartPhoto.Image != null)
            {
                SelectedProjectSectionPart.CoverImage = ImageHelpers.CopyImageToByteArray(imgPartPhoto.Image);
            }

            using var service = new ProjectSectionPartService(Globals.GetConnectionString());
            if (SelectedProjectSectionPart.Id > 0)
            {
                service.Update(SelectedProjectSectionPart);
            }
            else
            {
                SelectedProjectSectionPart.DigiAdminId = Globals.DigiAdministration.Id;
                SelectedProjectSectionPart.IsDeleted = false;
                SelectedProjectSectionPart.CreatedOn = DateTime.Now;
                SelectedProjectSectionPart.Id = service.Create(SelectedProjectSectionPart);
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

        #region Grids  & Datasources

        #region Grid & Datasource: Projects

        private void bsProjects_PositionChanged(object sender, EventArgs e)
        {
            
           if (sender is not BindingSource) return;
            if (BindingContext[bsProjects].Position <= -1) return;
            InProjectSelection = true;

            Application.DoEvents();

            SelectedProject = (Project)bsProjects.Current;
            LoadSelected_Project();
            if(!InProjectSectionSelection || !InProjectSectionPartSelection)  tabEditors.SelectedPage = tabProjectEditors;

            Filter.ProjectId = SelectedProject.Id;
            Filter.ProjectSectionId = 0;
            Filter.ProjectSectionPartId = 0;
            ucProjectDocs1.InitializeData(ProjectControlEnum.Project, Filter);

            Application.DoEvents();
            InProjectSelection = false;

        }

        #endregion

        #region Grid & Datasource: Sections

        private void bsSections_PositionChanged(object sender, EventArgs e)
        {
            
            if (sender is not BindingSource) return;
            InProjectSectionSelection = true;
            if (BindingContext[bsSections].Position <= -1) return;

            Application.DoEvents();
            SelectedProjectSection = (ProjectSection)bsSections.Current;
            LoadSelected_ProjectSection();
            if (!InProjectSelection || !InProjectSectionPartSelection) tabEditors.SelectedPage = tabSectionEditors;

            Filter.ProjectSectionId = SelectedProjectSection.Id;
            Filter.ProjectSectionPartId = 0;
            ucProjectDocs1.InitializeData(ProjectControlEnum.ProjectSection, Filter);

            Application.DoEvents();

            InProjectSectionSelection = false;
        }

        private void gvProjectSections_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (sender is not GridView view) return;

            if (e.Column == view.Columns[nameof(ProjectSection.ProjectName)])
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }


        #endregion

        #region Grid & Datasource: Parts

        private void bsParts_PositionChanged(object sender, EventArgs e)
        {
           // if (InProjectSelection || InProjectSectionSelection || InProjectSectionPartSelection) return;

            if (sender is not BindingSource) return;
            InProjectSectionPartSelection = true;
            if (BindingContext[bsParts].Position <= -1) return;

            Application.DoEvents();
            SelectedProjectSectionPart = (ProjectSectionPart)bsParts.Current;
            LoadSelected_ProjectSectionPart();
            if(!InProjectSectionSelection || !InProjectSelection) tabEditors.SelectedPage = tabPartsEditors;

            Filter.ProjectSectionPartId = SelectedProjectSectionPart.Id;
            ucProjectDocs1.InitializeData(ProjectControlEnum.ProjectSectionPart, Filter);

            Application.DoEvents();

            InProjectSectionPartSelection = false;
        }

        private void gvProjectSectionParts_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (sender is not GridView view) return;

            if (e.Column == view.Columns[nameof(ProjectSectionPart.ProjectName)] || e.Column == view.Columns[nameof(ProjectSectionPart.ProjectSectionName)])
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }

        #endregion

        #endregion

        #region Projects

        #region Editor

        private void btnProjectAddNew_Click(object sender, EventArgs e)
        {
            SelectedProject = new Project();
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
            if (SelectedProject.Id <= 0) return;

            SelectedProject.IsDeleted = false;
            SelectedProject.IsActive = true;

            using var service = new ProjectService(Globals.GetConnectionString());
            service.Update(SelectedProject);

            LoadGrid_Projects();
        }

        private void btnProjectSave_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void btnProjectDelete_Click(object sender, EventArgs e)
        {
            if (SelectedProject.Id <= 0) return;
            var service = new ProjectService(Globals.GetConnectionString());
            service.Delete(SelectedProject.Id, false);
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

            SelectedProject = new Project();
            SelectedProjectSection = new ProjectSection();
            SelectedProjectSectionPart = new ProjectSectionPart();

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

            SelectedProject = new Project();
            SelectedProjectSection = new ProjectSection();
            SelectedProjectSectionPart = new ProjectSectionPart();

            LoadGrid_Projects();

            Application.DoEvents();
        }


        #endregion

        #endregion
        
        #region Sections

        #region Editor

        private void btnSectionAddNew_Click(object sender, EventArgs e)
        {
            SelectedProjectSection = new ProjectSection();
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
            if (SelectedProjectSection.Id <= 0) return;

            SelectedProjectSection.IsDeleted = false;
            SelectedProjectSection.IsActive = true;

            using var service = new ProjectSectionService(Globals.GetConnectionString());
            service.Update(SelectedProjectSection);

            LoadGrid_ProjectSections();
        }

        private void btnSectionDelete_Click(object sender, EventArgs e)
        {
            if (SelectedProjectSection.Id <= 0) return;
            var service = new ProjectSectionService(Globals.GetConnectionString());
            service.Delete(SelectedProjectSection.Id, false);
            LoadGrid_ProjectSections();
            Application.DoEvents();
        }

        #endregion

        #endregion

        #region Tabs

        private void tabEditors_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {

        }

        #endregion

        #region Parts

        #region Editor

        private void btnPartAddNew_Click(object sender, EventArgs e)
        {
            SelectedProjectSectionPart = new ProjectSectionPart();
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
            if (SelectedProjectSectionPart.Id <= 0) return;

            SelectedProjectSectionPart.IsDeleted = false;
            SelectedProjectSectionPart.IsActive = true;

            using var service = new ProjectSectionPartService(Globals.GetConnectionString());
            service.Update(SelectedProjectSectionPart);

            LoadGrid_ProjectSectionParts();
        }

        private void btnPartSave_Click(object sender, EventArgs e)
        {
            SaveProjectSectionPart();
        }

        private void btnPartDelete_Click(object sender, EventArgs e)
        {
            if (SelectedProjectSectionPart.Id <= 0) return;
            var service = new ProjectSectionPartService(Globals.GetConnectionString());
            service.Delete(SelectedProjectSectionPart.Id, false);
            LoadGrid_ProjectSectionParts();
            Application.DoEvents();
        }




















        #endregion

        #endregion

        #endregion

        #region General Helper Methods

        
        private void HideStandardGridColumns(GridView gridView)
        {
            if (gridView.Columns[nameof(Project.Id)] != null) gridView.Columns[nameof(Project.Id)].Visible = false;
            if (gridView.Columns[nameof(Project.CreatedOn)] != null) gridView.Columns[nameof(Project.CreatedOn)].Visible = false;
            if (gridView.Columns[nameof(Project.DigiAdminId)] != null) gridView.Columns[nameof(Project.DigiAdminId)].Visible = false;
            if (gridView.Columns[nameof(Project.DigiAdmin)] != null) gridView.Columns[nameof(Project.DigiAdmin)].Visible = false;
            if (gridView.Columns[nameof(Project.IsActive)] != null) gridView.Columns[nameof(Project.IsActive)].Visible = false;
            if (gridView.Columns[nameof(Project.IsDeleted)] != null) gridView.Columns[nameof(Project.IsDeleted)].Visible = false;


            if (gridView.Columns[nameof(ProjectSection.Project)] != null) gridView.Columns[nameof(ProjectSection.Project)].Visible = false;
            if (gridView.Columns[nameof(ProjectSection.ProjectId)] != null) gridView.Columns[nameof(ProjectSection.ProjectId)].Visible = false;

            if (gridView.Columns[nameof(ProjectSectionPart.ProjectSectionId)] != null) gridView.Columns[nameof(ProjectSectionPart.ProjectSectionId)].Visible = false;
            if (gridView.Columns[nameof(ProjectSectionPart.ProjectSection)] != null) gridView.Columns[nameof(ProjectSectionPart.ProjectSection)].Visible = false;

        }







        #endregion

        
    }
}