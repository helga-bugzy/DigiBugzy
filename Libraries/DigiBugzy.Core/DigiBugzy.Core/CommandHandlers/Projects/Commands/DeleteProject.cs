
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Projects.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Projects.Commands
{
    public class DeleteProjectRequest : IMapFrom<DeleteProjectCommand>, IRequestObject
    {
        public ProjectModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteProjectCommand, DeleteProjectRequest>();
    }

    public class DeleteProjectDto : IMapFrom<DeleteProjectResponse>
    {
        public ProjectModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteProjectResponse, DeleteProjectDto>();
    }


    public class DeleteProjectResponse : BaseResponseObject
    {
        public ProjectModel Model { get; set; }
    }


    public class DeleteProjectCommand : IRequest<DeleteProjectDto>
    {
        public ProjectModel Model { get; set; }


        public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, DeleteProjectDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public DeleteProjectCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<DeleteProjectDto> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<DeleteProjectResponse, DeleteProjectRequest>(_mapper.Map<DeleteProjectRequest>(request));
                return _mapper.Map<DeleteProjectDto>(response);

            }

        }
    }
}
