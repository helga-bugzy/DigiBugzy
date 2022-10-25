using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Data.Common.xBaseObjects;
using DigiBugzy.Services.Projects;

namespace DigiBugzy.Desktop.Projects.UserControls
{
    public partial class ucProjectPrinting : XtraUserControl
    {
        #region Properties

        private ProjectPrinting _selectedPrinting { get; set; } = new();
        
        public ProjectPrinting SelectedPrinting
        {
            get => _selectedPrinting;
            set => _selectedPrinting = value;
        }

        public ProjectPrintingFilter Filter { get; set; } = new();

        private ProjectControlEnum Type { get; set; }

        private bool IsInitializing { get; set; }

        #endregion

        #region Ctor

        public ucProjectPrinting()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public void InitializeData(ProjectControlEnum type, ProjectPrintingFilter filter)
        {
            Type = type;
            Filter = filter;
            IsInitializing = true;
            progressPanel1.Visible = true;
            Application.DoEvents();

            LoadGrid();

            progressPanel1.Visible = false;
            Application.DoEvents();
        }

        #endregion

        #region Helper Methods

        private void LoadGrid()
        {
            try
            {
                using var service = new ProjectPrintingService(Globals.GetConnectionString());
                var collection = service.Get(Filter);
                bindingSource1.DataSource = collection;
                gridListing.DataSource = bindingSource1;

                HideGridColumns();
                GenerateGridBands();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void GenerateGridBands()
        {
            #region Band: File Info

            if (gvListing.Bands[nameof(gbFileInfo)] != null)
            {
                gbFileInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.Picture)]);
                gbFileInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.Name)]);
                gbFileInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.RequiredQuantity)]);
                gbFileInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.ActualQuantity)]);
            }
            #endregion

            #region Band: Printing

            if (gvListing.Bands[nameof(gbFileInfo)] != null)
            {
                gbFileInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.PrinterId)]);
            }

            #endregion

            #region Band: Project

            if (gvListing.Bands[nameof(gbProjectInfo)] != null)
            {
                gbProjectInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.ProjectId)]);
                gbProjectInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.ProjectSectionId)]);
                gbProjectInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.ProjectSectionPartId)]);
            }

            #endregion

            #region Band: Filament Info

            if(gvListing.Bands[nameof(gbFilamentInfo)] != null)
            {
                gbFilamentInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.ActualFilamentColorId)]);
                gbFilamentInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.ActualFilamentTypeId)]);
                gbFilamentInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.RequiredFilamentColorId)]);
                gbFilamentInfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.RequiredFilamentTypeId)]);
            }

            #endregion

            #region Settings

            if (gvListing.Bands[nameof(gbPrintingSettings)] != null)
            {
                gbPrintingSettings.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.Infil)]);
                gbPrintingSettings.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.WallThickness)]);
                gbPrintingSettings.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.FilamentUsedGram)]);
                gbPrintingSettings.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.FilamentUsedMeter)]);
                gbPrintingSettings.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.ResolutionId)]);
            }

            #endregion

            #region Time

            if (gvListing.Bands[nameof(gbTimeINfo)] != null)
            {
                gbTimeINfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.EstimatedPrintTime)]);
                gbTimeINfo.Columns.Add(gvListing.Columns[nameof(ProjectPrinting.ActualPrintTime)]);
            }

            #endregion
        }

        private void HideGridColumns()
        {
            //Base Columns
            if (gvListing.Columns[nameof(ProjectPrinting.Id)] != null) gvListing.Columns[nameof(ProjectPrinting.Id)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.DigiAdmin)] != null) gvListing.Columns[nameof(ProjectPrinting.DigiAdmin)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.DigiAdminId)] != null) gvListing.Columns[nameof(ProjectPrinting.DigiAdminId)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.CreatedOn)] != null) gvListing.Columns[nameof(ProjectPrinting.CreatedOn)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.IsActive)] != null) gvListing.Columns[nameof(ProjectPrinting.IsActive)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.IsDeleted)] != null) gvListing.Columns[nameof(ProjectPrinting.IsDeleted)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.Description)] != null) gvListing.Columns[nameof(ProjectPrinting.Description)].Visible = false;

            //Files
            if (gvListing.Columns[nameof(ProjectPrinting.GCodeFile)] != null) gvListing.Columns[nameof(ProjectPrinting.GCodeFile)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.StlFile)] != null) gvListing.Columns[nameof(ProjectPrinting.StlFile)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.CadFile)] != null) gvListing.Columns[nameof(ProjectPrinting.CadFile)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.GCodeFile)] != null) gvListing.Columns[nameof(ProjectPrinting.StlFileName)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.StlFile)] != null) gvListing.Columns[nameof(ProjectPrinting.IsGCodeMade)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.CadFile)] != null) gvListing.Columns[nameof(ProjectPrinting.CadFile)].Visible = false;


            //Objects
            if (gvListing.Columns[nameof(ProjectPrinting.Resolution)] != null) gvListing.Columns[nameof(ProjectPrinting.Resolution)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.ActualFilamentColor)] != null) gvListing.Columns[nameof(ProjectPrinting.ActualFilamentColor)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.ActualFilamentType)] != null) gvListing.Columns[nameof(ProjectPrinting.ActualFilamentType)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.RequiredFilamentColor)] != null) gvListing.Columns[nameof(ProjectPrinting.RequiredFilamentColor)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.RequiredFilamentType)] != null) gvListing.Columns[nameof(ProjectPrinting.RequiredFilamentType)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.Printer)] != null) gvListing.Columns[nameof(ProjectPrinting.Printer)].Visible = false;

            if (gvListing.Columns[nameof(ProjectPrinting.Project)] != null) gvListing.Columns[nameof(ProjectPrinting.Project)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.ProjectSection)] != null) gvListing.Columns[nameof(ProjectPrinting.ProjectSection)].Visible = false;
            if (gvListing.Columns[nameof(ProjectPrinting.ProjectSectionPart)] != null) gvListing.Columns[nameof(ProjectPrinting.ProjectSectionPart)].Visible = false;
        }
    }
    #endregion

}



