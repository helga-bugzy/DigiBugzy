using System.Drawing;
using System.IO;
using DigiBugzy.Core.Domain.Administration.Documents;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Services.Administration.Documents;
using DigiBugzy.Services.Projects;

namespace DigiBugzy.Desktop.Projects.UserControls
{
    public partial class ucProjectDocs : DevExpress.XtraEditors.XtraUserControl
    {
        #region Properties

        private ProjectDocument _selectedDocument { get; set; } = new();

        public ProjectDocument SelectedDocument
        {
            get => _selectedDocument;
            set
            {
                _selectedDocument = value;
                LoadEditor();
            }
        }

        public ProjectDocumentFilter Filter { get; set; } = new();

        private ProjectControlEnum Type { get; set; }

        private bool IsInitializing { get; set; }

        #endregion

        #region Ctor

        public ucProjectDocs()
        {
            InitializeComponent();
        }

        #endregion

        #region Control Event Procedure(s)

        #region Filter

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter.Only3DPrintingDocument = rd3D.Checked;
            Filter.OnlyInstructions = rdInstructions.Checked;
            Filter.OnlyPlans = rdPlans.Checked;
            Filter.OnlySpecifications = rdSpecs.Checked;
            Filter.IncludePartSearch = chkFilterPart.Checked;
            Filter.IncludeProjectSearch = chkFilterProject.Checked;
            Filter.IncludeSectionSearch = chkFilterSection.Checked;
        }

        #endregion

        #region Editor

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearErrorIndicators();
            ResetEditor(true);
            Application.DoEvents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDocument();
            SelectedDocument = new ProjectDocument();
            Application.DoEvents();



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
            Application.DoEvents();

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.InitialDirectory = "c:\\";
            if (xtraOpenFileDialog1.ShowDialog() != DialogResult.OK) return;

            lblSelectedDocumentName.Text = xtraOpenFileDialog1.FileName;

        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProject.SelectedIndex <= 0) 
                cmbProject.SelectedIndex = 1;
            var item = (Project)cmbProject.SelectedItem;
            SelectedDocument.ProjectId = item.Id;
            ValidateControl(cmbProject, SelectedDocument.ProjectId);
            LoadCombo_Section();
            Application.DoEvents();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSection.SelectedIndex <= 0)
                return;

            var item = (ProjectSection)cmbSection.SelectedItem;
            SelectedDocument.ProjectSectionId = item.Id;
            LoadCombo_Parts();
            Application.DoEvents();
        }

        private void cmbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPart.SelectedIndex <= 0) return;
            var item = (ProjectSectionPart)cmbPart.SelectedItem;
            SelectedDocument.ProjectSectionPartId = item.Id;
            Application.DoEvents();
        }

        private void cmbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDocumentType.SelectedIndex < 0) return;

                var item = (DocumentType)cmbDocumentType.SelectedItem;

                if (item == null) return;
                SelectedDocument.DocumentTypeId = item.Id;
                ValidateControl(cmbDocumentType, SelectedDocument.DocumentTypeId);
            }
            catch
            {
                SelectedDocument.DocumentTypeId = 0;
                ValidateControl(cmbDocumentType, SelectedDocument.DocumentTypeId);
            }

        }

        private void cmbDocumentFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumentFileType.SelectedIndex < 0) return;
            var item = (DocumentFileType)cmbDocumentFileType.SelectedItem;
            SelectedDocument.DocumentFileTypeId = item.Id;
            ValidateControl(cmbDocumentFileType, SelectedDocument.DocumentFileTypeId);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ValidateControl(txtName);
        }
        
        #endregion

        #endregion

        #region Public Methods

        public void InitializeData(ProjectControlEnum type, ProjectDocumentFilter filter)
        {
            Type = type;
            Filter = filter;
            
            IsInitializing = true;

            progressPanel1.Visible = true;
            Application.DoEvents();

            switch (type)
            {
                case ProjectControlEnum.Project:
                    chkFilterProject.Checked = true;
                    break;
                case ProjectControlEnum.ProjectSection:
                    chkFilterProject.Checked = true;
                    chkFilterSection.Checked = true;
                    break;
                case ProjectControlEnum.ProjectSectionPart:
                    chkFilterProject.Checked = true;
                    chkFilterSection.Checked = true;
                    chkFilterPart.Checked = true;
                    break;
                default:
                    chkFilterProject.Checked = true;
                    break;
            }

            LoadCombo_DocumentFileTypes();
            LoadCombo_DocumentTypes();
            LoadCombo_Project();
            LoadCombo_Section();
            LoadCombo_Parts();

            LoadGrid();
            LoadEditor();
            LoadBaseViewer();

            progressPanel1.Visible = false;
            IsInitializing = false;
            Application.DoEvents();

        }

        #region Helper Methods

        #region Grid

        public void LoadGrid()
        {
            var service = new ProjectDocumentService(Globals.GetConnectionString());
            var collection = service.Get(Filter);
            bindingSource1.DataSource = collection;
            gridDocuments.DataSource = bindingSource1;


            if (gvDocuments.Columns[nameof(ProjectDocument.CreatedOn)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.CreatedOn)].Visible = false;

            if (gvDocuments.Columns[nameof(ProjectDocument.DigiAdmin)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionId)].Visible = false;
            if (gvDocuments.Columns[nameof(ProjectDocument.DigiAdminId)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionPartId)].Visible = false;
            if (gvDocuments.Columns[nameof(ProjectDocument.IsActive)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionId)].Visible = false;
            if (gvDocuments.Columns[nameof(ProjectDocument.IsDeleted)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionPartId)].Visible = false;

            if (gvDocuments.Columns[nameof(ProjectDocument.ProjectId)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectId)].Visible = false;
            if (gvDocuments.Columns[nameof(ProjectDocument.Project)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.Project)].Visible = false;

            if (gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionId)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionId)].Visible = false;
            if (gvDocuments.Columns[nameof(ProjectDocument.ProjectSection)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectSection)].Visible = false;

            if (gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionPartId)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionPartId)].Visible = false;
            if (gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionPart)] != null) 
                gvDocuments.Columns[nameof(ProjectDocument.ProjectSectionPart)].Visible = false;

            Application.DoEvents();
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            if (sender is not BindingSource) return;

            if (!IsInitializing)
            {
                progressPanel1.Visible = true;
                Application.DoEvents();
            }
            if (BindingContext[bindingSource1].Position <= -1) return;
            SelectedDocument = (ProjectDocument)bindingSource1.Current;

            if (!IsInitializing) progressPanel1.Visible = true;
            Application.DoEvents();
        }

        #endregion

        #region Editor

        private void LoadCombo_Project()
        {
            cmbProject.Items.Clear();
            cmbSection.Items.Clear();
            cmbPart.Items.Clear();

            cmbSection.Enabled = cmbPart.Enabled = false;

            var service = new ProjectService(Globals.GetConnectionString());
            var collection = service.Get(new StandardFilter(includeDeleted: false, includeInActive: false));


            cmbProject.Items.Add("<Select a Project>");
            var index = 1;
            foreach (var item in collection)
            {
                cmbProject.Items.Add(item);
                if (SelectedDocument.ProjectId == item.Id)
                {
                    cmbProject.SelectedIndex = index;
                }

                index += 1;
            }

            LoadCombo_Section();

            Application.DoEvents();

        }

        private void LoadCombo_Section()
        {
            cmbSection.Enabled = true;
            cmbSection.Items.Clear();
            cmbPart.Items.Clear();
            cmbPart.Enabled = false;

            if (SelectedDocument.Id < 0 || SelectedDocument.ProjectId <= 0)
            {
                cmbSection.Enabled = false;
                return;
            }


            var service = new ProjectSectionService(Globals.GetConnectionString());
            var collection = service.Get(new StandardFilter(includeDeleted: false, includeInActive: false), SelectedDocument.ProjectId);

            cmbSection.Items.Add("<Select a Section>");

            if (collection.Count <= 0)
            {
                cmbSection.Enabled = false;
                return;
            }


            var index = 1;
            foreach (var item in collection)
            {
                cmbSection.Items.Add(item);
                if (SelectedDocument.ProjectSectionId == item.Id)
                {
                    cmbSection.SelectedIndex = index;
                }

                index += 1;
            }

            LoadCombo_Parts();

            Application.DoEvents();


        }

        private void LoadCombo_Parts()
        {
            cmbPart.Enabled = true;
            cmbPart.Items.Clear();

            if (SelectedDocument.Id < 0 || SelectedDocument.ProjectSectionId <= 0)
            {
                cmbPart.Enabled = false;
                return;
            }

            var service = new ProjectSectionPartService(Globals.GetConnectionString());
            var collection = service.Get(
                new StandardFilter(includeDeleted: false, includeInActive: false),
                SelectedDocument.ProjectSectionId ?? 0);

            cmbSection.Items.Add("<Select a Part>");

            if (collection.Count <= 0)
            {
                cmbPart.Enabled = false;
                return;
            }

            var index = 1;
            foreach (var item in collection)
            {
                cmbPart.Items.Add(item);
                if (SelectedDocument.ProjectSectionPartId == item.Id)
                {
                    cmbPart.SelectedIndex = index;
                }

                index += 1;
            }

            Application.DoEvents();
        }

        private void LoadCombo_DocumentTypes()
        {
            cmbDocumentType.Items.Clear();
            using var service = new DocumentTypeService(Globals.GetConnectionString());
            var collection = service.Get(new StandardFilter() { ClassificationId = (int)ClassificationsEnum.Project });

            var index = 1;
            foreach (var item in collection)
            {
                cmbDocumentType.Items.Add(item);
                if (SelectedDocument.DocumentTypeId == item.Id)
                {
                    cmbDocumentType.SelectedIndex = index;
                }

                index += 1;
            }

            if (cmbDocumentType.SelectedIndex >= 0) return;

            cmbDocumentType.SelectedIndex = 0;
            var dt = (DocumentType)cmbDocumentType.SelectedItem;
            SelectedDocument.DocumentTypeId = dt.Id;
        }

        private void LoadCombo_DocumentFileTypes()
        {
            cmbDocumentType.Items.Clear();
            using var service = new DocumentFileTypeService(Globals.GetConnectionString());
            var collection = service.Get(new StandardFilter() { ClassificationId = (int)ClassificationsEnum.Project });

            var index = 1;
            foreach (var item in collection)
            {
                cmbDocumentFileType.Items.Add(item);
                if (SelectedDocument.DocumentFileTypeId == item.Id)
                {
                    cmbDocumentFileType.SelectedIndex = index;
                }

                index += 1;
            }

            if (cmbDocumentFileType.SelectedIndex >= 0) return;

            cmbDocumentFileType.SelectedIndex = 0;
            var dft = (DocumentFileType)cmbDocumentFileType.SelectedItem;
            SelectedDocument.DocumentFileTypeId = dft.Id;
        }

        private void LoadEditor()
        {
            ResetEditor(false);

            if (_selectedDocument.Id != 0)
            {
                _selectedDocument.CreatedOn = DateTime.Now;
                _selectedDocument.DigiAdminId = Globals.DigiAdministration.Id;
                _selectedDocument.IsActive = true;
                _selectedDocument.IsDeleted = false;
                btnSelectFile.Enabled = btnSave.Enabled = true;
            }
            else
            {


                txtDescription.Text = _selectedDocument.Description;
                txtName.Text = _selectedDocument.Name;
                chkIs3DPrintingDocument.Checked = _selectedDocument.Is3DPrintingDocument;
                chkIsInstructions.Checked = _selectedDocument.IsInstructions;
                chkIsPlans.Checked = _selectedDocument.IsPlans;
                chkIsSpecifications.Checked = _selectedDocument.IsSpecifications;
                btnSelectFile.Enabled = btnAdd.Enabled = btnDelete.Enabled = btnSave.Enabled = true;

                cmbProject.Items.Clear();
                LoadCombo_Project();
            }


            LoadCombo_Project();
        }

        private void LoadBaseViewer()
        {
            ucBaseViewer1.LoadDocument(SelectedDocument.DocumentData, SelectedDocument.DocumentFileTypeId);
        }

        private void SaveDocument()
        {
            try
            {
                if (!ValidateSave()) return;

                //Set description if not provided
                if (string.IsNullOrEmpty(txtDescription.Text)) txtDescription.Text = txtName.Text;

                //Update information
                SelectedDocument.Name = txtName.Text;
                SelectedDocument.Description = txtDescription.Text;
                SelectedDocument.Is3DPrintingDocument = chkIs3DPrintingDocument.Checked;
                SelectedDocument.IsInstructions = chkIsInstructions.Checked;
                SelectedDocument.IsPlans = chkIsPlans.Checked;
                SelectedDocument.IsSpecifications = chkIsSpecifications.Checked;
                SelectedDocument.DocumentData = GetDocument();

                using var service = new ProjectDocumentService(Globals.GetConnectionString());
                if (SelectedDocument.Id <= 0)
                {
                    SelectedDocument.CreatedOn = DateTime.Now;
                    SelectedDocument.DigiAdminId = Globals.DigiAdministration.Id;
                    SelectedDocument.IsActive = true;
                    SelectedDocument.IsDeleted = false;
                    SelectedDocument.Id = service.Create(SelectedDocument);
                }
                else
                {
                    service.Update(SelectedDocument);
                }

                btnAdd.Enabled = btnDelete.Enabled = true;
                ClearErrorIndicators();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show($"Error saving document {e.Message}");
            }
        }

        private byte[] GetDocument()
        {
            try
            {
                // Read the contents of the file into a stream.
                var fileStream = xtraOpenFileDialog1.OpenFile();
                using var reader = new StreamReader(fileStream);
                using var br = new BinaryReader(reader.BaseStream);
                var bytes = br.ReadBytes((int)reader.BaseStream.Length);

                return bytes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return SelectedDocument.DocumentData;
            }
        }

        private void DeleteDocument()
        {
            var service = new ProjectDocumentService(Globals.GetConnectionString());
            service.Delete(SelectedDocument, true);

            ResetEditor(true);

        }

        private bool ValidateSave()
        {
            var success = true;

            try
            {
                ClearErrorIndicators();

                if (!ValidateControl(cmbDocumentFileType, SelectedDocument.DocumentFileTypeId)) success = false;
                if (!ValidateControl(cmbDocumentType, SelectedDocument.DocumentTypeId)) success = false;
                if (!ValidateControl(cmbProject, SelectedDocument.ProjectId)) success = false;
                if (!ValidateControl(txtName)) success = false;
                
                if (string.IsNullOrEmpty(xtraOpenFileDialog1.FileName))
                {
                    lblSelectedDocumentName.ForeColor = Color.Red;
                    lblSelectedDocumentName.Text = "No file selected";
                    success = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void ClearErrorIndicators()
        {
            try
            {
                cmbDocumentFileType.BackColor = cmbDocumentType.BackColor = cmbProject.BackColor = txtName.BackColor = Color.White;
                cmbDocumentFileType.ForeColor = cmbDocumentType.ForeColor = cmbProject.ForeColor = txtName.ForeColor = lblSelectedDocumentName.ForeColor = Color.Black;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private bool ValidateControl(Control control)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                control.BackColor = Color.Red;
                control.ForeColor = Color.White;
                return false;
            }
            else
            {
                control.BackColor = Color.White;
                control.ForeColor = Color.Black;
                return true;
            }
        }

        private bool ValidateControl(System.Windows.Forms.ComboBox control, int id)
        {
            if (id <= 0)
            {
                control.BackColor = Color.Red;
                control.ForeColor = Color.White;
                return false;
            }

            control.BackColor = Color.White;
            control.ForeColor = Color.Black;
            return true;
        }

        private void ResetEditor(bool fullReset)
        {

            if (fullReset) SelectedDocument = new ProjectDocument();

            cmbProject.Items.Clear();
            cmbSection.Items.Clear();
            cmbPart.Items.Clear();

            SelectedDocument.ProjectId = Filter.ProjectId;
            if (Filter.ProjectSectionId > 0) SelectedDocument.ProjectSectionId = Filter.ProjectSectionId;
            if (Filter.ProjectSectionPartId > 0) SelectedDocument.ProjectSectionPartId = Filter.ProjectSectionPartId;

            LoadCombo_DocumentFileTypes();
            LoadCombo_DocumentTypes();
            LoadCombo_Project();

            txtDescription.Text = txtName.Text = string.Empty;
            chkIs3DPrintingDocument.Checked = chkIsInstructions.Checked = chkIsPlans.Checked = chkIsSpecifications.Checked = false;

            xtraOpenFileDialog1.Reset();

            btnAdd.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = true;

            ClearErrorIndicators();
        }

        #endregion



        #endregion

        #endregion


    }
}
