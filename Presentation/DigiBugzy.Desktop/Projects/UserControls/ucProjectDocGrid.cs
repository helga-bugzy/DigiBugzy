

using DevExpress.XtraEditors;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Core.EventHandlers;
using DigiBugzy.Services.Projects;

namespace DigiBugzy.Desktop.Projects.UserControls
{
    public partial class ucProjectDocGrid : XtraUserControl
    {
        #region Events

        public event SelectedDocumentChangedEvent? SelectedDocumentChanged;

        public delegate void SelectedDocumentChangedEvent(object sender, SelectedProjectDocumentChangedEventArgs e);

        #endregion

        #region Properties

        private ProjectControlEnum ProjectControlType { get; set; }

        private ProjectDocumentFilter Filter { get; set; } = new();

        #endregion

        #region Ctor

        public ucProjectDocGrid()
        {
            
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public void LoadData(ProjectControlEnum type, ProjectDocumentFilter filter)
        {
            ProjectControlType = type;
            Filter = filter;

            var service = new ProjectDocumentService(Globals.GetConnectionString());
            var collection = service.Get(filter);
            bindingSource1.DataSource = collection;
            gridDocuments.DataSource = bindingSource1;
        }

        #endregion

        #region Control Event Procedures

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            if (sender is not BindingSource) return;
            if (BindingContext[bindingSource1].Position <= -1) return;

            SelectedDocumentChanged?.Invoke(null, new SelectedProjectDocumentChangedEventArgs((ProjectDocument)bindingSource1.Current));
        }

        #endregion
    }
}
