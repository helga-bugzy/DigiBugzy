

namespace DigiBugzy.ApplicationLayer.Sections.Products.Commands.CreateProduct
{
    public class CreateProjectRequest : IMapFrom<CreateProjectCommand>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BugzerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectCommand, CreateProjectRequest>();
        }
    }
}
