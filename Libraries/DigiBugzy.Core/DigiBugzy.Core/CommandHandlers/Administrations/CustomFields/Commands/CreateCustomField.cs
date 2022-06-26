
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Commands
{
    public class CreateCustomFieldRequest : IMapFrom<CreateCustomFieldCommand>, IRequestObject
    {
        public CustomFieldModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateCustomFieldCommand, CreateCustomFieldRequest>();
    }

    public class CreateCustomFieldDto : IMapFrom<CreateCustomFieldResponse>
    {
        public CustomFieldModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateCustomFieldResponse, CreateCustomFieldDto>();
    }


    public class CreateCustomFieldResponse : BaseResponseObject
    {
        public CustomFieldModel Model { get; set; }
    }


    public class CreateCustomFieldCommand : IRequest<CreateCustomFieldDto>
    {
        public CustomFieldModel Model { get; set; }


        public class CreateCustomFieldCommandHandler : IRequestHandler<CreateCustomFieldCommand, CreateCustomFieldDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateCustomFieldCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<CreateCustomFieldDto> Handle(CreateCustomFieldCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateCustomFieldResponse, CreateCustomFieldRequest>(_mapper.Map<CreateCustomFieldRequest>(request));
                return _mapper.Map<CreateCustomFieldDto>(response);

            }

        }
    }
}
