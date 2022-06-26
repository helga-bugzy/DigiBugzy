

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Queries
{
    public class GetCustomFieldValuesResponse: IResponseObject
    {
        [JsonPropertyName("customfieldvalues")]
        public List<ClassificationModel> Models { get; set; }


    }

    public class GetCustomFieldValuesDto: IMapFrom<GetCustomFieldValuesResponse>
    {
        [JsonPropertyName("customfieldvalues")]
        public List<ClassificationModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetCustomFieldValuesResponse, GetCustomFieldValuesDto>();
    }

    public class GetCustomFieldValuesQuery: IRequest<IEnumerable<GetCustomFieldValuesDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetCustomFieldValuesQueryHandler : IRequestHandler<GetCustomFieldValuesQuery, IEnumerable<GetCustomFieldValuesDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetCustomFieldValuesQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetCustomFieldValuesDto>> Handle(GetCustomFieldValuesQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetCustomFieldValuesResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetCustomFieldValuesDto>>(results);
            }
        }
    }
}
