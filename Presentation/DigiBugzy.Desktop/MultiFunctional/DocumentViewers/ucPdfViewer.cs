using System.IO;
using DevExpress.XtraEditors;

namespace DigiBugzy.Desktop.MultiFunctional.DocumentViewers
{
    public partial class ucPdfViewer : XtraUserControl
    {
        #region Properties

        public byte[] DocumentData { get; set; } = Array.Empty<byte>();

        #endregion

        #region Ctor

        public ucPdfViewer()
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
            pdfViewer1.LoadDocument(memStream);
        }

        #endregion


    }
}
