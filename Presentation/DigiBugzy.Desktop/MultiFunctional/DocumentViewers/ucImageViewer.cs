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

namespace DigiBugzy.Desktop.MultiFunctional.DocumentViewers
{
    public partial class ucImageViewer : XtraUserControl
    {
        #region Properties

        public byte[] DocumentData { get; set; } = Array.Empty<byte>();

        #endregion

        #region Ctor

        public ucImageViewer()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads pdf document to control and display
        /// </summary>
        /// <param name="documentData"></param>
        public void LoadDocument(byte[] documentData)
        {
            DocumentData = documentData;
            var memStream = new MemoryStream(DocumentData);
            //pictureBox1.LoadImage(memStream);
            
        }

        #endregion
    }
}
