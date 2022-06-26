
namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.DigiAdmins.Commands
{

    public class CreateDigiAdminRequest : IMapFrom<CreateDigiAdminCommand>, IRequestObject
    {
        public DigiAdminModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateDigiAdminCommand, CreateDigiAdminRequest>();
    }

    public class CreateDigiAdminDto : IMapFrom<CreateDigiAdminResponse>
    {
        public DigiAdminModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateDigiAdminResponse, CreateDigiAdminDto>();
    }


    public class CreateDigiAdminResponse : BaseResponseObject
    {
        public DigiAdminModel Model { get; set; }
    }    

   
    public class CreateDigiAdminCommand : IRequest<CreateDigiAdminDto>
    {
        public DigiAdminModel Model { get; set; }


        public class CreateDigiAdminCommandHandler : IRequestHandler<CreateDigiAdminCommand, CreateDigiAdminDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateDigiAdminCommandHandler(IApiHandler digiAdminsApi, IMapper mapper)
            {
                _apiHandler = digiAdminsApi;
                _mapper = mapper;
            }

            public async Task<CreateDigiAdminDto> Handle(CreateDigiAdminCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateDigiAdminResponse, CreateDigiAdminRequest>(_mapper.Map<CreateDigiAdminRequest>(request));
                return _mapper.Map<CreateDigiAdminDto>(response);

            }

        }
    }
}

