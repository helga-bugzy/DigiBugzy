
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Commands
{

    public class UpdateCategoryRequest : IMapFrom<UpdateCategoryCommand>, IRequestObject
    {
        public CategoryModel Properties { get; set; }
        

        public void Mapping(Profile profile) => profile.CreateMap<UpdateCategoryCommand, UpdateCategoryRequest>();
    }

    public class UpdateCategoryDto : IMapFrom<UpdateCategoryResponse>
    {
        public CategoryModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateCategoryResponse, UpdateCategoryDto>();
    }


    public class UpdateCategoryResponse : BaseResponseObject
    {
        public CategoryModel Properties { get; set; }
    }


    public class UpdateCategoryCommand : IRequest<UpdateCategoryDto>
    {
        public CategoryModel Properties { get; set; }


        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateCategoryCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateCategoryResponse, UpdateCategoryRequest>(_mapper.Map<UpdateCategoryRequest>(request));
                return _mapper.Map<UpdateCategoryDto>(response);

            }

        }
    }
}
