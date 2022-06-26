
namespace DigiBugzy.ApplicationLayer.Sections.Products
{
    public interface IProductsApi
    {
        Task<IEnumerable<GetAllProductsResponse>> GetAllProducts();

        Task<CreateProductResponse> CreateProduct(CreateProductRequest request);

    }
}
