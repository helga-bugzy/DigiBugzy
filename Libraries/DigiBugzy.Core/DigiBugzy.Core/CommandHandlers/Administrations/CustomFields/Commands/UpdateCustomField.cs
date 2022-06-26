
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.CustomFields.Commands
{

    public class UpdateCustomFieldRequest : IMapFrom<UpdateCustomFieldCommand>, IRequestObject
    {
        public CustomFieldModel Properties { get; set; }
        

        public void Mapping(Profile profile) => profile.CreateMap<UpdateCustomFieldCommand, UpdateCustomFieldRequest>();
    }

    public class UpdateCustomFieldDto : IMapFrom<UpdateCustomFieldResponse>
    {
        public CustomFieldModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateCustomFieldResponse, UpdateCustomFieldDto>();
    }


    public class UpdateCustomFieldResponse : BaseResponseObject
    {
        public CustomFieldModel Properties { get; set; }
    }


    public class UpdateCustomFieldCommand : IRequest<UpdateCustomFieldDto>
    {
        public CustomFieldModel Properties { get; set; }


        public class UpdateCustomFieldCommandHandler : IRequestHandler<UpdateCustomFieldCommand, UpdateCustomFieldDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateCustomFieldCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateCustomFieldDto> Handle(UpdateCustomFieldCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateCustomFieldResponse, UpdateCustomFieldRequest>(_mapper.Map<UpdateCustomFieldRequest>(request));
                return _mapper.Map<UpdateCustomFieldDto>(response);

            }

        }
    }
}
