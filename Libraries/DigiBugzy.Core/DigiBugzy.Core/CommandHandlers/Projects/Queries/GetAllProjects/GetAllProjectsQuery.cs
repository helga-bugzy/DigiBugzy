

namespace DigiBugzy.ApplicationLayer.Sections.Products.Queries.GetAllProducts
{
    public class GetAllProjectsQuery: IRequest<IEnumerable<GetAllProjectsDto>>
    {
        public class GetAllPostsQueryHandler: IRequestHandler<GetAllProjectsQuery, IEnumerable<GetAllProjectsDto>>
        {
            private readonly IProjectsApi _productsApi;
            private readonly IMapper _mapper;

            public GetAllPostsQueryHandler(IProjectsApi productsApi, IMapper mapper)
            {
                _productsApi = productsApi;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<GetAllProjectsDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productsApi.GetAllProducts();
                return _mapper.Map<IEnumerable<GetAllProjectsDto>>(products);
            }
        }
    }
}
