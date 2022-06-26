

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Queries
{
    public class GetClassificationsResponse: IResponseObject
    {
        [JsonPropertyName("classifications")]
        public List<ClassificationModel> Models { get; set; }


    }

    public class GetClassificationsDto: IMapFrom<GetClassificationsResponse>
    {
        [JsonPropertyName("classifications")]
        public List<ClassificationModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetClassificationsResponse, GetClassificationsDto>();
    }

    public class GetClassificationsQuery: IRequest<IEnumerable<GetClassificationsDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetClassificationsQueryHandler : IRequestHandler<GetClassificationsQuery, IEnumerable<GetClassificationsDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetClassificationsQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetClassificationsDto>> Handle(GetClassificationsQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetClassificationsResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetClassificationsDto>>(results);
            }
        }
    }
}
