

namespace DigiBugzy.ApplicationLayer.Sections.Products.Commands.CreateProduct
{
    public class CreateProductRequest : IMapFrom<CreateProductCommand>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BugzerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductCommand, CreateProductRequest>();
        }
    }
}
