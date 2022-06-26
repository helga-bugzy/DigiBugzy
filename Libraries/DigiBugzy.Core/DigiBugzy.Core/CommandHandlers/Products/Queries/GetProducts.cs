

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Queries
{
    public class GetProductsResponse: IResponseObject
    {
        [JsonPropertyName("Products")]
        public List<ClassificationModel> Models { get; set; }


    }

    public class GetProductsDto: IMapFrom<GetProductsResponse>
    {
        [JsonPropertyName("Products")]
        public List<ClassificationModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetProductsResponse, GetProductsDto>();
    }

    public class GetProductsQuery: IRequest<IEnumerable<GetProductsDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<GetProductsDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetProductsQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetProductsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetProductsResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetProductsDto>>(results);
            }
        }
    }
}
