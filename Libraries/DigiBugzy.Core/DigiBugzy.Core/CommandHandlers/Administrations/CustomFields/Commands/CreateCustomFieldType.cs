
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Commands
{
    public class CreateCustomFieldTypeRequest : IMapFrom<CreateCustomFieldTypeCommand>, IRequestObject
    {
        public CustomFieldTypeModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateCustomFieldTypeCommand, CreateCustomFieldTypeRequest>();
    }

    public class CreateCustomFieldTypeDto : IMapFrom<CreateCustomFieldTypeResponse>
    {
        public CustomFieldTypeModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateCustomFieldTypeResponse, CreateCustomFieldTypeDto>();
    }


    public class CreateCustomFieldTypeResponse : BaseResponseObject
    {
        public CustomFieldTypeModel Properties { get; set; }
    }


    public class CreateCustomFieldTypeCommand : IRequest<CreateCustomFieldTypeDto>
    {
        public CustomFieldTypeModel Properties { get; set; }


        public class CreateCustomFieldTypeCommandHandler : IRequestHandler<CreateCustomFieldTypeCommand, CreateCustomFieldTypeDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateCustomFieldTypeCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<CreateCustomFieldTypeDto> Handle(CreateCustomFieldTypeCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateCustomFieldTypeResponse, CreateCustomFieldTypeRequest>(_mapper.Map<CreateCustomFieldTypeRequest>(request));
                return _mapper.Map<CreateCustomFieldTypeDto>(response);

            }

        }
    }
}
