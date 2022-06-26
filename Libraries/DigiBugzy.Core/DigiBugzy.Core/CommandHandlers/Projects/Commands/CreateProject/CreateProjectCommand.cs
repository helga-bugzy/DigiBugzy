
namespace DigiBugzy.ApplicationLayer.CommandHandlers.Products.Commands.CreateProduct
{
    public class CreateProjectCommand: IRequest<CreateProjectDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BugzerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectResponse, CreateProjectDto>();
        }

        public class CreateProjectCommandHandler: IRequestHandler<CreateProjectCommand, CreateProjectDto>()
        {
            private readonly IProjectsApi _projectsApi;
            private readonly IMapper _mapper;

            public CreateProjectCommandHandler(IProjectsApi projectsApi, IMapper mapper)
            {
                _projectsApi = projectsApi;
                _mapper = mapper;
            }

            public async Task<CreateProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
            {
                var response = await _projectsApi.CreateProduct(_mapper.Map<CreateProjectRequest>(request));
                return _mapper.Map<CreateProjectDto>(response);
            }
        }
    }
}
