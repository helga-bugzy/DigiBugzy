
namespace DigiBugzy.ApplicationLayer.Sections.Products
{
    public interface IProjectsApi
    {
        Task<IEnumerable<GetAllProjectsResponse>> GetAllProducts();

        Task<CreateProjectResponse> CreateProduct(CreateProjectRequest request);

    }
}
