

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Queries
{
    public class GetCustomFieldsResponse: IResponseObject
    {
        [JsonPropertyName("customfields")]
        public List<ClassificationModel> Models { get; set; }


    }

    public class GetCustomFieldsDto: IMapFrom<GetCustomFieldsResponse>
    {
        [JsonPropertyName("customfields")]
        public List<ClassificationModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetCustomFieldsResponse, GetCustomFieldsDto>();
    }

    public class GetCustomFieldsQuery: IRequest<IEnumerable<GetCustomFieldsDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetCustomFieldsQueryHandler : IRequestHandler<GetCustomFieldsQuery, IEnumerable<GetCustomFieldsDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetCustomFieldsQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetCustomFieldsDto>> Handle(GetCustomFieldsQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetCustomFieldsResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetCustomFieldsDto>>(results);
            }
        }
    }
}
