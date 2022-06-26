

namespace DigiBugzy.ApplicationLayer.Sections.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery: IRequest<IEnumerable<GetAllProductsDto>>
    {
        public class GetAllPostsQueryHandler: IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsDto>>
        {
            private readonly IProductsApi _productsApi;
            private readonly IMapper _mapper;

            public GetAllPostsQueryHandler(IProductsApi productsApi, IMapper mapper)
            {
                _productsApi = productsApi;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<GetAllProductsDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productsApi.GetAllProducts();
                return _mapper.Map<IEnumerable<GetAllProductsDto>>(products);
            }
        }
    }
}
