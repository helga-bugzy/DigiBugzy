
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Products.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Products.Commands
{
    public class CreateProductRequest : IMapFrom<CreateProductCommand>, IRequestObject
    {
        public ProductModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateProductCommand, CreateProductRequest>();
    }

    public class CreateProductDto : IMapFrom<CreateProductResponse>
    {
        public ProductModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateProductResponse, CreateProductDto>();
    }


    public class CreateProductResponse : BaseResponseObject
    {
        public ProductModel Model { get; set; }
    }


    public class CreateProductCommand : IRequest<CreateProductDto>
    {
        public ProductModel Model { get; set; }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateProductResponse, CreateProductRequest>(_mapper.Map<CreateProductRequest>(request));
                return _mapper.Map<CreateProductDto>(response);

            }

        }
    }
}
