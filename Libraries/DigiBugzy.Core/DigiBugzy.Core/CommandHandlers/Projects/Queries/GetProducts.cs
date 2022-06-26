

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Queries
{
    public class GetProjectsResponse: IResponseObject
    {
        [JsonPropertyName("Projects")]
        public List<ClassificationModel> Models { get; set; }


    }

    public class GetProjectsDto: IMapFrom<GetProjectsResponse>
    {
        [JsonPropertyName("Projects")]
        public List<ClassificationModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetProjectsResponse, GetProjectsDto>();
    }

    public class GetProjectsQuery: IRequest<IEnumerable<GetProjectsDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IEnumerable<GetProjectsDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetProjectsQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetProjectsDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetProjectsResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetProjectsDto>>(results);
            }
        }
    }
}
