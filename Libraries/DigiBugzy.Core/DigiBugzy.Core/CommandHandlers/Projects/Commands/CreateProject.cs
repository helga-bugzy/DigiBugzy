
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Projects.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Projects.Commands
{
    public class CreateProjectRequest : IMapFrom<CreateProjectCommand>, IRequestObject
    {
        public ProjectModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateProjectCommand, CreateProjectRequest>();
    }

    public class CreateProjectDto : IMapFrom<CreateProjectResponse>
    {
        public ProjectModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateProjectResponse, CreateProjectDto>();
    }


    public class CreateProjectResponse : BaseResponseObject
    {
        public ProjectModel Properties { get; set; }
    }


    public class CreateProjectCommand : IRequest<CreateProjectDto>
    {
        public ProjectModel Properties { get; set; }


        public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateProjectCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<CreateProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateProjectResponse, CreateProjectRequest>(_mapper.Map<CreateProjectRequest>(request));
                return _mapper.Map<CreateProjectDto>(response);

            }

        }
    }
}
