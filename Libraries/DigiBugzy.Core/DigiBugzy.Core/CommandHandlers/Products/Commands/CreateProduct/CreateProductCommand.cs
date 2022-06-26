
namespace DigiBugzy.ApplicationLayer.Sections.Products.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<CreateProductDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BugzerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductResponse, CreateProductDto>();
        }
    }
}
