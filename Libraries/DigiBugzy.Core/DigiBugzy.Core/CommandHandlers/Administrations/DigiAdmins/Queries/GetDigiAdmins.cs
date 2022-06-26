

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.DigiAdmins.Queries
{
    public class GetDigiAdminsResponse: IResponseObject
    {
        [JsonPropertyName("digiadmins")]
        public List<ClassificationModel> Models { get; set; }


    }

    public class GetDigiAdminsDto: IMapFrom<GetDigiAdminsResponse>
    {
        [JsonPropertyName("digiadmins")]
        public List<ClassificationModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetDigiAdminsResponse, GetDigiAdminsDto>();
    }

    public class GetDigiAdminsQuery: IRequest<IEnumerable<GetDigiAdminsDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetDigiAdminsQueryHandler : IRequestHandler<GetDigiAdminsQuery, IEnumerable<GetDigiAdminsDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetDigiAdminsQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetDigiAdminsDto>> Handle(GetDigiAdminsQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetDigiAdminsResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetDigiAdminsDto>>(results);
            }
        }
    }
}
