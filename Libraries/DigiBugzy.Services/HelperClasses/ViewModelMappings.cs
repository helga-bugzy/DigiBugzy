
using DigiBugzy.Core.Utilities;
using DigiBugzy.Core.ViewModels.Administration;
using DigiBugzy.Core.ViewModels.Catalog;
using DigiBugzy.Services.Catalog.Products;
namespace DigiBugzy.Services.HelperClasses
{
    public static class ViewModelMappings
    {

        private static List<ProductGridViewModel> _viewModels;

        private static List<Category> _categories;

        private static string _connectionString;


        #region Products


        public static List<ProductGridViewModel> ConvertProductToView(List<Product> products, string connectionString, bool doParentGrouping)
        {
            _connectionString = connectionString;
            _viewModels = products.Select(product => ConvertProductToView(product, connectionString)).ToList();

            if (doParentGrouping)
                _viewModels = ConvertToHierarchy();

            return _viewModels;
        }

        public static ProductGridViewModel ConvertProductToView(Product product, string connectionString, bool addParentInfo = true)
        {
            _connectionString = connectionString;
            var model = new ProductGridViewModel
            {
                Id = product.Id,
                Name = product.Name,
                IsActive = product.IsActive,
                Image = product.ProductImage,
                ParentId = product.ParentId,
                QuantityOnOrder = product.QuantityOnOrder,
                QuantityReserved = product.QuantityReserved,
                TotalInStock = product.TotalInStock,
                TotalValue = product.TotalValue
            };

            if (product.ParentId == null) return model;

            if (!addParentInfo) return model;
            using var productService = new ProductService(connectionString);
            var parent = productService.GetById(product.ParentId.Value);

            model.ParentName = parent.Name;

            return model;

        }

        public static List<ProductGridViewModel> ConvertToHierarchy()
        {
            var results = new List<ProductGridViewModel>();
            var parents = (
                from p in _viewModels
                where p.ParentId == null
                select p).ToList();


            var pp =
                (from model in parents
                 where model.ParentId == null &&
                            !(from model2 in _viewModels where model2.ParentId == model.Id select model2).Any()
                 select model).ToList();
           

            parents.AddRange(pp);

            foreach (var parent in parents)
            {
                parent.SubProducts = CreateChildProducts(parent.Id);
                results.Add(parent);
            }

            return results.OrderBy(p => p.Name).ToList();

        }

        public static List<ProductGridViewModel> CreateChildProducts(int parentId)
        {
            var result = new List<ProductGridViewModel>();
            var children = _viewModels.Where(c => c.ParentId == parentId);

            foreach (var child in children)
            {
                child.SubProducts = CreateChildProducts(child.Id).OrderBy(p => p.Name).ToList();
                result.Add(child);

            }

            return result;
        }

        #endregion

        #region Categories

        public static List<CategoryComboViewModel> CreateCategoryComboItems(List<Category> categories)
        {
            _categories = categories;
            var parents = (from c in categories where c.ParentId == null select c).OrderBy(c => c.Name).ToList();

            var results = new List<CategoryComboViewModel>();

            foreach (var parent in parents)
            {
                var model = new CategoryComboViewModel { Name = parent.Name, Id = parent.Id };
                results.Add(model);
                results.AddRange(CreateChildCategoryComboItems(parent.Id, 1));

            }

            return results;

        }

        private static List<CategoryComboViewModel> CreateChildCategoryComboItems(int parentId, int level)
        {
            var results = new List<CategoryComboViewModel>();
            var children = (from c in _categories where c.ParentId == parentId select c).OrderBy(c => c.Name);
            
            foreach (var child in children)
            {
                var model = new CategoryComboViewModel
                {
                    Id = child.Id,
                    Name = DigiUtilities.CreateLevelName(child.Name, level)
                };
                results.Add(model);

                results.AddRange(CreateChildCategoryComboItems(child.Id, level + 1));
            }

            return results;
        }


        #endregion

    }
}
