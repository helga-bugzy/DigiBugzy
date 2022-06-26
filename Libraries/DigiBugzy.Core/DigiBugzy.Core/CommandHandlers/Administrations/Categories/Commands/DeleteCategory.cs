
namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Commands
{
    public class DeleteCategoryRequest : IMapFrom<DeleteCategoryCommand>, IRequestObject
    {
        public CategoryModel Model { get; set; }


        public void Mapping(Profile profile) => profile.CreateMap<DeleteCategoryCommand, DeleteCategoryRequest>();
    }

    public class DeleteCategoryDto : IMapFrom<DeleteCategoryResponse>
    {
        public CategoryModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteCategoryResponse, DeleteCategoryDto>();
    }


    public class DeleteCategoryResponse : BaseResponseObject
    {
        public CategoryModel Model { get; set; }
    }


    public class DeleteCategoryCommand : IRequest<DeleteCategoryDto>
    {
        public CategoryModel Model { get; set; }


        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<DeleteCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<DeleteCategoryResponse, DeleteCategoryRequest>(_mapper.Map<DeleteCategoryRequest>(request));
                return _mapper.Map<DeleteCategoryDto>(response);

            }

        }
    }
}
