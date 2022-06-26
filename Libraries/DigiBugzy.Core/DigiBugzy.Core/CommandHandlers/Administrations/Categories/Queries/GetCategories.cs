

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Queries
{
    public class GetCategoriesResponse: IResponseObject
    {
        [JsonPropertyName("categories")]
        public List<CategoryModel> Models { get; set; }


    }

    public class GetCategoriesDto: IMapFrom<GetCategoriesResponse>
    {
        [JsonPropertyName("categories")]
        public List<CategoryModel> Models { get; set; }

        [JsonPropertyName("filter")]
        public StandardFilter Filter { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<GetCategoriesResponse, GetCategoriesDto>();
    }

    public class GetCategoriesQuery: IRequest<IEnumerable<GetCategoriesDto>>
    {
        public StandardFilter Filter { get; set; }

        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<GetCategoriesDto>>
        {
            public readonly IApiHandler _apiHandler;

            public readonly IMapper _mapper;

            public GetCategoriesQueryHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            

            public async Task<IEnumerable<GetCategoriesDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                var results = await _apiHandler.Get<GetCategoriesResponse, StandardFilter>(request.Filter);
                return _mapper.Map<IEnumerable<GetCategoriesDto>>(results);
            }
        }
    }
}
