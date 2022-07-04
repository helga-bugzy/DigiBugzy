
global using System.Collections.Generic;
global using System.Data;
global using System.Linq;

namespace DigiBugzy.Desktop.Administration
{
    public partial class ucCategoriesManager : UserControl
    {
        #region Properties

        private StandardFilter _filter { get; set; }

        private List<Category> _collection { get; set; }

        private int _selectedCategoryId { get; set; }

        #endregion

        #region Ctor

        public ucCategoriesManager()
        {
            InitializeComponent();
        }


        #endregion

        #region Data Loading/Binding

        /// <summary>
        /// Load categories to bind to treeview
        /// </summary>
        private void LoadCategories()
        {
            using(var service = Startup.GetService<CategoryService>())
            {
                if (service == null) return;
                _collection = service.Get(_filter);
            }

            BindCategories();
        }

        /// <summary>
        /// Bind categories to treeview starting at the parents
        /// </summary>
        private void BindCategories()
        {            
            if (_collection.Count <= 0) return;
            var parents = _collection.Where(x => x.ParentId == 0).ToList();
            if (parents.Count <= 0) return;

            foreach(var parent in parents)
            {
                var node = new TreeNode()
                {
                    Name = parent.Id.ToString(),
                    Text = parent.Name,
                    Tag = parent.Id.ToString()
                };

                treeData.Nodes.Add(node);
                BindCategories(parent.Id, node);
            }
            
        }

        /// <summary>
        /// Recursive loop to load parent children....
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="parentNode"></param>
        private void BindCategories(int parentId, TreeNode parentNode)
        {
            var children = _collection.Where(x => x.ParentId == parentId).ToList();
            if (children.Count <= 0) return;

            foreach(var child in children)
            {
                var node = new TreeNode()
                {
                    Name = child.Id.ToString(),
                    Text = child.Name,
                    Tag = child.Id.ToString()
                };

                treeData.Nodes.Add(node);
                BindCategories(child.Id, node);
            }
        }

        private void BindProducts()
        {
            using(var service = Startup.GetService<ProductService>())
            {
                if (service == null) return;
                var products = service.Get(new StandardFilter { CategoryId = _selectedCategoryId });
                grdProducts.DataSource = products;
            }
        }

        private void BindCustomFields()
        {
            using(var service = Startup.GetService<CustomFieldService>())
            {
                if (service == null) return;
                grdCustomFields.DataSource = service.Get(new StandardFilter { CategoryId = _selectedCategoryId });
            }
        }

        #endregion

        #region Control Event Procedures

        private void ctrlFilter_OnFilter(StandardFilter filter)
        {
            _filter = filter;
            LoadCategories();
            Application.DoEvents();
        }


        #endregion
    }
}
