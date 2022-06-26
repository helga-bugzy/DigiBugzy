
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Commands
{

    public class UpdateCustomFieldTypeRequest : IMapFrom<UpdateCustomFieldTypeCommand>, IRequestObject
    {
        public CustomFieldModel Model { get; set; }
        

        public void Mapping(Profile profile) => profile.CreateMap<UpdateCustomFieldTypeCommand, UpdateCustomFieldTypeRequest>();
    }

    public class UpdateCustomFieldTypeDto : IMapFrom<UpdateCustomFieldTypeResponse>
    {
        public CustomFieldModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateCustomFieldTypeResponse, UpdateCustomFieldTypeDto>();
    }


    public class UpdateCustomFieldTypeResponse : BaseResponseObject
    {
        public CustomFieldModel Model { get; set; }
    }


    public class UpdateCustomFieldTypeCommand : IRequest<UpdateCustomFieldTypeDto>
    {
        public CustomFieldModel Model { get; set; }


        public class UpdateCustomFieldTypeCommandHandler : IRequestHandler<UpdateCustomFieldTypeCommand, UpdateCustomFieldTypeDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateCustomFieldTypeCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateCustomFieldTypeDto> Handle(UpdateCustomFieldTypeCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateCustomFieldTypeResponse, UpdateCustomFieldTypeRequest>(_mapper.Map<UpdateCustomFieldTypeRequest>(request));
                return _mapper.Map<UpdateCustomFieldTypeDto>(response);

            }

        }
    }
}
