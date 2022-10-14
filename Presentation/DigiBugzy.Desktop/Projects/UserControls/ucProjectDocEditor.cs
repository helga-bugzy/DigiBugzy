using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Services.Projects;

namespace DigiBugzy.Desktop.Projects.UserControls
{
    public partial class ucProjectDocEditor : XtraUserControl
    {

        #region Delegates & Events

        public delegate void OnSaveDelegate(ProjectDocument selectedDocument);
        public event OnSaveDelegate? OnSave;

        #endregion
        
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

        private ProjectControlEnum Type { get;set; }

        private ProjectDocumentFilter Filter { get; set; }



        #endregion

        #region Public Methods

        public void InitializeData(ProjectControlEnum type, ProjectDocumentFilter filter)
        {
            Type = type;
            Filter = filter;

            LoadEditor();
          
        }

        #endregion

        #region Ctor

        public ucProjectDocEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region Control Event Procedure(s)

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SelectedDocument = new ProjectDocument();
            LoadEditor();
            Application.DoEvents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
            Application.DoEvents();
            OnSave?.Invoke(SelectedDocument);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.InitialDirectory = "c:\\";
            if (xtraOpenFileDialog1.ShowDialog() != DialogResult.OK) return;

            lblSelectedDocumentName.Text = xtraOpenFileDialog1.FileName;



        }

        #endregion

        #region Helper Methods

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
            foreach(var item in collection)
            {
                cmbProject.Items.Add(item);
                if(SelectedDocument.ProjectId == item.Id)
                {
                    cmbProject.SelectedIndex = index;
                }

                index += 1;
            }

            if(cmbProject.SelectedIndex > 0)
            {
                LoadCombo_Section();
            }

            Application.DoEvents();

        }

        private void LoadCombo_Section()
        {
            cmbSection.Items.Clear();
            cmbPart.Items.Clear();
            cmbPart.Enabled = false;

            if(SelectedDocument.Id <= 0 || cmbProject.SelectedIndex <= 0)
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

            if(cmbSection.SelectedIndex > 0)
            {
                LoadCombo_Parts();
            }

            Application.DoEvents();


        }

        private void LoadCombo_Parts()
        {
            cmbPart.Enabled = true;
            cmbPart.Items.Clear();

            if (SelectedDocument.Id <= 0 || cmbSection.SelectedIndex <= 0)
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

        private void LoadEditor()
        {
            txtDescription.Text = txtName.Text = string.Empty;
            chkIs3DPrintingDocument.Checked = chkIsInstructions.Checked = chkIsPlans.Checked = chkIsSpecifications.Checked = false;
            btnSelectFile.Enabled = btnAdd.Enabled = btnDelete.Enabled = btnSave.Enabled = false;
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
            }

        
            LoadCombo_Project();
        }

        private void SaveDocument()
        {
            // Read the contents of the file into a stream.
            var fileStream = xtraOpenFileDialog1.OpenFile();
            using var reader = new StreamReader(fileStream);
            using var br = new BinaryReader(reader.BaseStream);
            var bytes = br.ReadBytes((int)reader.BaseStream.Length);

            if (string.IsNullOrEmpty(txtDescription.Text)) txtDescription.Text = txtName.Text;


            SelectedDocument.Name = txtName.Text;
            SelectedDocument.Description = txtDescription.Text;
            SelectedDocument.Is3DPrintingDocument = chkIs3DPrintingDocument.Checked;
            SelectedDocument.IsInstructions = chkIsInstructions.Checked;
            SelectedDocument.IsPlans = chkIsPlans.Checked;
            SelectedDocument.IsSpecifications = chkIsSpecifications.Checked;
            SelectedDocument.DocumentData = bytes;

        }

  

        #endregion

        
    }
}
