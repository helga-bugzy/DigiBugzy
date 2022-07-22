

using System.Collections.Generic;
using System.Linq;

namespace DigiBugzy.Desktop.Administration.Categories
{
    public partial class CategoriesManager : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private readonly int _classificationId;

        private List<Category> Categories { get; set; } = new();


        #endregion

        #region Ctor

        public CategoriesManager(int classificationId )
        {
            _classificationId = classificationId;
            InitializeComponent();

            LoadClassifications();
        }

        #endregion

        #region Public Methods

        

        #endregion

        #region Helper Methods

        private void LoadClassifications()
        {
            using var service = new ClassificationService(Globals.GetConnectionString());

            var collection = service.Get(new StandardFilter());
            cmbClassifications.Items.Clear();
            cmbClassifications.DataSource = collection;
            cmbClassifications.DisplayMember = "Name";
            cmbClassifications.ValueMember = "Id";

            if (_classificationId > 0)
            {
                foreach (var item in cmbClassifications.Items)
                {
                    if (item is not Classification classification || classification.Id != _classificationId) continue;
                    cmbClassifications.SelectedItem = item;
                    LoadCategories();
                    break;
                }
            }

            Application.DoEvents();
        }

        private void LoadCategories()
        {
            treeCategories.ClearNodes();
            if (_classificationId <= 0) return;

            using var service = new CategoryService(Globals.GetConnectionString());
            Categories = service.Get(new StandardFilter());

            if(Categories is not { Count: > 0 }) return;

            LoadCategoryNodes();

        }

        private void LoadCategoryNodes()
        {
            //Get all parents
            var parents = (from c in Categories
                    where c.ParentId == 0
                    select new Category
                    {
                        Id = c.Id, ParentId = c.ParentId, Name = c.Name, IsActive = c.IsActive, IsDeleted = c.IsDeleted
                    })
                .ToList();

            //Loop and add
            foreach (var parent in parents)
            {
                var node = new TreeNode(text: parent.Name)
                {
                    Tag = parent.Id
                };
                LoadCategoryNodes(node);

                treeCategories.Nodes.Add(node);
            }


        }

        private void LoadCategoryNodes(TreeNode? parentNode)
        {
            if (parentNode == null) return;
            var children = Categories
                .Where(c => c.ParentId == int.Parse(parentNode.Tag.ToString()!))
                .Select(c => new Category
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    IsDeleted = c.IsDeleted
                })
                .ToList();

            if (children.Count > 0)
            {
                foreach (var child in children)
                {
                    var node = new TreeNode(text: child.Name)
                    {
                        Tag = child.Id
                    };
                    parentNode.Nodes.Add(node);

                    LoadCategoryNodes(node);
                }
            }
        }

        #endregion


    }
}