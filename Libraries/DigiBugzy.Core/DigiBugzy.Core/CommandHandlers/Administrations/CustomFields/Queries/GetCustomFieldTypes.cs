

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Queries
{
    public class GetCustomFieldTypesResponse: IResponseObject
    {
        [JsonPropertyName("customfieldtypes")]
        public List<ClassificationModel> Models { get; set; }


    }

    public class GetCustomFieldTypesDto: IMapFrom<GetCustomFieldTypesResponse>
    {
        [JsonPropertyName("customfieldtypes")]
        public List<ClassificationModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetCustomFieldTypesResponse, GetCustomFieldTypesDto>();
    }

    public class GetCustomFieldTypesQuery: IRequest<IEnumerable<GetCustomFieldTypesDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetCustomFieldTypesQueryHandler : IRequestHandler<GetCustomFieldTypesQuery, IEnumerable<GetCustomFieldTypesDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetCustomFieldTypesQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetCustomFieldTypesDto>> Handle(GetCustomFieldTypesQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetCustomFieldTypesResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetCustomFieldTypesDto>>(results);
            }
        }
    }
}
