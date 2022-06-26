
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFieldValues.Commands
{
    public class DeleteCustomFieldValueRequest : IMapFrom<DeleteCustomFieldValueCommand>, IRequestObject
    {
        public CustomFieldValueModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteCustomFieldValueCommand, DeleteCustomFieldValueRequest>();
    }

    public class DeleteCustomFieldValueDto : IMapFrom<DeleteCustomFieldValueResponse>
    {
        public CustomFieldValueModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteCustomFieldValueResponse, DeleteCustomFieldValueDto>();
    }


    public class DeleteCustomFieldValueResponse : BaseResponseObject
    {
        public CustomFieldValueModel Model { get; set; }
    }


    public class DeleteCustomFieldValueCommand : IRequest<DeleteCustomFieldValueDto>
    {
        public CustomFieldValueModel Model { get; set; }


        public class DeleteCustomFieldValueCommandHandler : IRequestHandler<DeleteCustomFieldValueCommand, DeleteCustomFieldValueDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public DeleteCustomFieldValueCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<DeleteCustomFieldValueDto> Handle(DeleteCustomFieldValueCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<DeleteCustomFieldValueResponse, DeleteCustomFieldValueRequest>(_mapper.Map<DeleteCustomFieldValueRequest>(request));
                return _mapper.Map<DeleteCustomFieldValueDto>(response);

            }

        }
    }
}
