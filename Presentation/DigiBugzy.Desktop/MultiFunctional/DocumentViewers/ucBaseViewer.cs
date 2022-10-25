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

namespace DigiBugzy.Desktop.MultiFunctional.DocumentViewers
{
    public partial class ucBaseViewer : DevExpress.XtraEditors.XtraUserControl
    {
        private byte[]? _documentData;

        public ucBaseViewer()
        {
            InitializeComponent();
        }

        public void LoadDocument(byte[]? documentData, int documentFileTypeId)
        {
            if (documentData is not { Length: > 0 }) return;
            _documentData = documentData;

            Controls.Clear();

            var eType = (DocumentFileTypeEnum)documentFileTypeId;

            switch (eType)
            {
                case DocumentFileTypeEnum.PdfDocument:
                    LoadPdf();
                    break;
            }
        }

        private void LoadPdf()
        {
            if (_documentData is not { Length: > 0 }) return;
            var control = new ucPdfViewer();
            control.DocumentData = _documentData;
            control.Dock = DockStyle.Fill;
            Controls.Add(control);
            Application.DoEvents();
        }
    }
}
