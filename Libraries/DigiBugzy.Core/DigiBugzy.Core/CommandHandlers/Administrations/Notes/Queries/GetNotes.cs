

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Queries
{
    public class GetNotesResponse: IResponseObject
    {
        [JsonPropertyName("notes")]
        public List<ClassificationModel> Models { get; set; }


    }

    public class GetNotesDto: IMapFrom<GetNotesResponse>
    {
        [JsonPropertyName("notes")]
        public List<ClassificationModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetNotesResponse, GetNotesDto>();
    }

    public class GetNotesQuery: IRequest<IEnumerable<GetNotesDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, IEnumerable<GetNotesDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetNotesQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetNotesDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetNotesResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetNotesDto>>(results);
            }
        }
    }
}
