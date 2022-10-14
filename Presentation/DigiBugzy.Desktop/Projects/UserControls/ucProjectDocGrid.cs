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

namespace DigiBugzy.Desktop.Projects.UserControls
{
    public partial class ucProjectDocGrid : DevExpress.XtraEditors.XtraUserControl
    {
        #region Properties

        private ProjectControlEnum ProjectControlType { get; set; }

        private ProjectDocumentFilter Filter { get; set; }

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
        }

        #endregion
    }
}
