
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Products.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Products.Commands
{

    public class UpdateProductRequest : IMapFrom<UpdateProductCommand>, IRequestObject
    {
        public ProductModel Model { get; set; }
        

        public void Mapping(Profile profile) => profile.CreateMap<UpdateProductCommand, UpdateProductRequest>();
    }

    public class UpdateProductDto : IMapFrom<UpdateProductResponse>
    {
        public ProductModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateProductResponse, UpdateProductDto>();
    }


    public class UpdateProductResponse : BaseResponseObject
    {
        public ProductModel Model { get; set; }
    }


    public class UpdateProductCommand : IRequest<UpdateProductDto>
    {
        public ProductModel Model { get; set; }


        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateProductResponse, UpdateProductRequest>(_mapper.Map<UpdateProductRequest>(request));
                return _mapper.Map<UpdateProductDto>(response);

            }

        }
    }
}
