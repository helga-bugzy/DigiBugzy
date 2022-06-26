
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFieldTypes.Commands
{
    public class DeleteCustomFieldTypeRequest : IMapFrom<DeleteCustomFieldTypeCommand>, IRequestObject
    {
        public CustomFieldTypeModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteCustomFieldTypeCommand, DeleteCustomFieldTypeRequest>();
    }

    public class DeleteCustomFieldTypeDto : IMapFrom<DeleteCustomFieldTypeResponse>
    {
        public CustomFieldTypeModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteCustomFieldTypeResponse, DeleteCustomFieldTypeDto>();
    }


    public class DeleteCustomFieldTypeResponse : BaseResponseObject
    {
        public CustomFieldTypeModel Properties { get; set; }
    }


    public class DeleteCustomFieldTypeCommand : IRequest<DeleteCustomFieldTypeDto>
    {
        public CustomFieldTypeModel Properties { get; set; }


        public class DeleteCustomFieldTypeCommandHandler : IRequestHandler<DeleteCustomFieldTypeCommand, DeleteCustomFieldTypeDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public DeleteCustomFieldTypeCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<DeleteCustomFieldTypeDto> Handle(DeleteCustomFieldTypeCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<DeleteCustomFieldTypeResponse, DeleteCustomFieldTypeRequest>(_mapper.Map<DeleteCustomFieldTypeRequest>(request));
                return _mapper.Map<DeleteCustomFieldTypeDto>(response);

            }

        }
    }
}
