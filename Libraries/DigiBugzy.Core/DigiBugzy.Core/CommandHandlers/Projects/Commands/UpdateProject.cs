
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Projects.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Projects.Commands
{

    public class UpdateProjectRequest : IMapFrom<UpdateProjectCommand>, IRequestObject
    {
        public ProjectModel Properties { get; set; }
        

        public void Mapping(Profile profile) => profile.CreateMap<UpdateProjectCommand, UpdateProjectRequest>();
    }

    public class UpdateProjectDto : IMapFrom<UpdateProjectResponse>
    {
        public ProjectModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateProjectResponse, UpdateProjectDto>();
    }


    public class UpdateProjectResponse : BaseResponseObject
    {
        public ProjectModel Properties { get; set; }
    }


    public class UpdateProjectCommand : IRequest<UpdateProjectDto>
    {
        public ProjectModel Properties { get; set; }


        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, UpdateProjectDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateProjectCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateProjectResponse, UpdateProjectRequest>(_mapper.Map<UpdateProjectRequest>(request));
                return _mapper.Map<UpdateProjectDto>(response);

            }

        }
    }
}
