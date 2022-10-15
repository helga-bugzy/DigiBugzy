
using DevExpress.XtraEditors;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Services.Projects;

namespace DigiBugzy.Desktop.Projects.UserControls
{
    public partial class ucProjectDocManager : XtraUserControl
    {
        #region Properties

        public ProjectControlEnum ProjectControlType { get; set; } = new();

        public ProjectDocumentFilter Filter { get; set; } = new();


        #endregion

        #region Ctor

        public ucProjectDocManager()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public void LoadData(ProjectControlEnum type, ProjectDocumentFilter filter)
        {
            Filter = filter;

            grid.LoadData(type, filter);
            editor.InitializeData(type, filter);
        }

        #endregion

        #region Control Event Procedure(s)

        private void editor_OnSave(ProjectDocument selectedDocument)
        {
            grid.LoadData(ProjectControlType, Filter);
            Application.DoEvents();
        }

        private void editor_OnDelete()
        {
            grid.LoadData(ProjectControlType, Filter);
            Application.DoEvents();
        }

        private void grid_SelectedDocumentChanged(object sender, Core.EventHandlers.SelectedProjectDocumentChangedEventArgs e)
        {
            editor.SelectedDocument = e.SelectedDocument;
        }

        #endregion


    }
}
