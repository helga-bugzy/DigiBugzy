
using DigiBugzy.Core.ViewModels.Catalog;
using DigiBugzy.Services.Catalog.Products;
namespace DigiBugzy.Services.HelperClasses
{
    public static class ViewModelMappings
    {

        private static List<ProductGridViewModel> _viewModels;

        private static string _connectionString;
        
        

        public static List<ProductGridViewModel> ConvertProductToView(List<Product> products, string connectionString, bool doParentGrouping)
        {
            _connectionString = connectionString;
            _viewModels =products.Select(product => ConvertProductToView(product, connectionString)).ToList();

            if (doParentGrouping)
                _viewModels = ConvertToHierarchy();

            return _viewModels;
        }

        public static ProductGridViewModel ConvertProductToView(Product product, string connectionString, bool addParentInfo = true)
        {
            _connectionString = connectionString;
            var model =  new ProductGridViewModel
            {
                Id = product.Id,
                Name = product.Name,
                IsActive = product.IsActive,
                Image = product.ProductImage,
                ParentId = product.ParentId
            };

            if (product.ParentId == null) return model;

            if (addParentInfo)
            {
                using var productService = new ProductService(connectionString);
                var parent = productService.GetById(product.ParentId.Value, false);

                model.ParentName = parent.Name;
            }

            return model;
        }

        public static List<ProductGridViewModel> ConvertToHierarchy()
        {
            var results = new List<ProductGridViewModel>();
            var parents = (from p in _viewModels where p.ParentId == null select p).ToList();

            var pp = from model in parents
                where model.ParentId == null &&
                      !(from model2 in _viewModels where model2.ParentId == model.Id select model2).Any()
                select model;

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
    }
}
