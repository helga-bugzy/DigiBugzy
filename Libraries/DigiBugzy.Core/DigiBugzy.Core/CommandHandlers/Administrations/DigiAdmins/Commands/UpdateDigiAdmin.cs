

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.DigiAdmins.Commands
{
    public class UpdateDigiAdminRequest : IMapFrom<UpdateDigiAdminCommand>, IRequestObject
    {
        public DigiAdminModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateDigiAdminCommand, UpdateDigiAdminRequest>();
    }

    public class UpdateDigiAdminDto : IMapFrom<UpdateDigiAdminResponse>
    {
        public DigiAdminModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateDigiAdminResponse, UpdateDigiAdminDto>();
    }


    public class UpdateDigiAdminResponse : BaseResponseObject
    {
        public DigiAdminModel Model { get; set; }
    }


    public class UpdateDigiAdminCommand : IRequest<UpdateDigiAdminDto>
    {
        public DigiAdminModel Model { get; set; }


        public class UpdateDigiAdminCommandHandler : IRequestHandler<UpdateDigiAdminCommand, UpdateDigiAdminDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateDigiAdminCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateDigiAdminDto> Handle(UpdateDigiAdminCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateDigiAdminResponse, UpdateDigiAdminRequest>(_mapper.Map<UpdateDigiAdminRequest>(request));
                return _mapper.Map<UpdateDigiAdminDto>(response);

            }

        }
    }
}
