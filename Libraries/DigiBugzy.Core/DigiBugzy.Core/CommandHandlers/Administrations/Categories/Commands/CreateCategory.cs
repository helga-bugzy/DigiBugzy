

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Commands
{
    public class CreateCategoryRequest : IMapFrom<CreateCategoryCommand>, IRequestObject
    {
        public CategoryModel Model { get; set; }

        public StandardFilter Filter { get; set; } = new();
       
        public void Mapping(Profile profile) => profile.CreateMap<CreateCategoryCommand, CreateCategoryRequest>();

    }

    public class CreateCategoryDto : IMapFrom<CreateCategoryResponse>
    {
        public CategoryModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateCategoryResponse, CreateCategoryDto>();
    }


    public class CreateCategoryResponse : BaseResponseObject
    {
        public CategoryModel Model { get; set; }
    }


    public class CreateCategoryCommand : IRequest<CreateCategoryDto>
    {
        public CategoryModel Model { get; set; }


        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<CreateCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateCategoryResponse, CreateCategoryRequest>(_mapper.Map<CreateCategoryRequest>(request));
                return _mapper.Map<CreateCategoryDto>(response);

            }

        }
    }
}
