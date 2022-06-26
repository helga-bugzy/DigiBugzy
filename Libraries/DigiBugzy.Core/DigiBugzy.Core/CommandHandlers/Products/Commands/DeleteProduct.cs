
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Products.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Products.Commands
{
    public class DeleteProductRequest : IMapFrom<DeleteProductCommand>, IRequestObject
    {
        public ProductModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteProductCommand, DeleteProductRequest>();
    }

    public class DeleteProductDto : IMapFrom<DeleteProductResponse>
    {
        public ProductModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteProductResponse, DeleteProductDto>();
    }


    public class DeleteProductResponse : BaseResponseObject
    {
        public ProductModel Properties { get; set; }
    }


    public class DeleteProductCommand : IRequest<DeleteProductDto>
    {
        public ProductModel Properties { get; set; }


        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public DeleteProductCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<DeleteProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<DeleteProductResponse, DeleteProductRequest>(_mapper.Map<DeleteProductRequest>(request));
                return _mapper.Map<DeleteProductDto>(response);

            }

        }
    }
}
