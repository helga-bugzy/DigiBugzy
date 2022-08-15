using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DigiBugzy.Services.HelperClasses;

namespace DigiBugzy.Desktop.Products
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();

            LoadFilter(true);
        }

        private void LoadFilter(bool clearSelectedProduct)
        {

            var filter = new StandardFilter();

            using var service = new ProductService(Globals.GetConnectionString());
            var viewModels = ViewModelMappings.ConvertProductToView(service.Get(filter, loadProductComplete: true), Globals.GetConnectionString(), true);

            gridControl1.DataSource = viewModels;
            //gvProducts.Columns["Id"].Visible = false;
            //gvProducts.Columns["ParentId"].Visible = false;
            //gvProducts.Columns["ParentName"].Visible = false;

            foreach (GridView view in gridControl1.ViewCollection)
            {
                var x = view.Name;
                view.Columns["Id"].Visible = false;
                view.Columns["ParentId"].Visible = false;
                view.Columns["ParentName"].Visible = false;
                
            }

            //LoadSelectedProduct(clearSelectedProduct ? 0 : SelectedProduct.Id);
        }

    }
}