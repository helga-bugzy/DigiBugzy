
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
    }
}
