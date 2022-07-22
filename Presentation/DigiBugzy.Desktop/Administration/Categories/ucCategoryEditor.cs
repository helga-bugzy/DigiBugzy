using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace DigiBugzy.Desktop.Administration.Categories
{
    public partial class ucCategoryEditor : XtraUserControl
    {
        private int _categoryId = 0;
        private int _classificationId = 0;

        public ucCategoryEditor(int classificationId, int categoryId = 0)
        {
            _categoryId = categoryId;
            _classificationId = classificationId;
            InitializeComponent();

            LoadCategoryEditor(0,0);
        }

        public void LoadCategoryEditor(int classificationId, int categoryId = 0)
        {
            _categoryId = categoryId;
            _classificationId = classificationId;

            LoadClassifications();
        }

        #region Helper Methods


        private void LoadClassifications()
        {
            

        }

        private void LoadParents()
        {

        }

        private void LoadCategory()
        {

        }

        #endregion
    }
}
