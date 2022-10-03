using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace DigiBugzy.Desktop.MultiFunctional.DocumentViewers
{
    public partial class ucPdfViewer : DevExpress.XtraEditors.XtraUserControl
    {
        private byte[] _documentData;
        public byte[] DocumentData
        {
            get => _documentData;
            set
            {
                _documentData = value;
                LoadDocument();
            }
        }

        public ucPdfViewer()
        {
            InitializeComponent();
        }

        public void LoadDocument()
        {
            var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(_documentData, 0, _documentData.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            {
                var obj = (object)binForm.Deserialize(memStream);
            }
        }
           
 
    }
}
