

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Products.Commands.CreateProduct
{
    public class CreateProjectDto: IMapFrom<CreateProjectResponse>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectResponse, CreateProjectDto>();
        }
    }
}
