
namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Commands
{

    public class UpdateCustomFieldValueRequest : IMapFrom<UpdateCustomFieldValueCommand>, IRequestObject
    {
        public CustomFieldModel Model { get; set; }
        

        public void Mapping(Profile profile) => profile.CreateMap<UpdateCustomFieldValueCommand, UpdateCustomFieldValueRequest>();
    }

    public class UpdateCustomFieldValueDto : IMapFrom<UpdateCustomFieldValueResponse>
    {
        public CustomFieldModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateCustomFieldValueResponse, UpdateCustomFieldValueDto>();
    }


    public class UpdateCustomFieldValueResponse : BaseResponseObject
    {
        public CustomFieldModel Model { get; set; }
    }


    public class UpdateCustomFieldValueCommand : IRequest<UpdateCustomFieldValueDto>
    {
        public CustomFieldModel Model { get; set; }


        public class UpdateCustomFieldValueCommandHandler : IRequestHandler<UpdateCustomFieldValueCommand, UpdateCustomFieldValueDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateCustomFieldValueCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateCustomFieldValueDto> Handle(UpdateCustomFieldValueCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateCustomFieldValueResponse, UpdateCustomFieldValueRequest>(_mapper.Map<UpdateCustomFieldValueRequest>(request));
                return _mapper.Map<UpdateCustomFieldValueDto>(response);

            }

        }
    }
}
