
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Commands
{
    public class CreateCustomFieldValueRequest : IMapFrom<CreateCustomFieldValueCommand>, IRequestObject
    {
        public CustomFieldValueModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateCustomFieldValueCommand, CreateCustomFieldValueRequest>();
    }

    public class CreateCustomFieldValueDto : IMapFrom<CreateCustomFieldValueResponse>
    {
        public CustomFieldValueModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateCustomFieldValueResponse, CreateCustomFieldValueDto>();
    }


    public class CreateCustomFieldValueResponse : BaseResponseObject
    {
        public CustomFieldValueModel Model { get; set; }
    }


    public class CreateCustomFieldValueCommand : IRequest<CreateCustomFieldValueDto>
    {
        public CustomFieldValueModel Model { get; set; }


        public class CreateCustomFieldValueCommandHandler : IRequestHandler<CreateCustomFieldValueCommand, CreateCustomFieldValueDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateCustomFieldValueCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<CreateCustomFieldValueDto> Handle(CreateCustomFieldValueCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateCustomFieldValueResponse, CreateCustomFieldValueRequest>(_mapper.Map<CreateCustomFieldValueRequest>(request));
                return _mapper.Map<CreateCustomFieldValueDto>(response);

            }

        }
    }
}
