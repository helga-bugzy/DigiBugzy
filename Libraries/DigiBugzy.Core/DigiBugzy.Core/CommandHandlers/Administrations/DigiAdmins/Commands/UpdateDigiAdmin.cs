

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.DigiAdmins.Commands
{
    public class UpdateDigiAdminRequest : IMapFrom<UpdateDigiAdminCommand>, IRequestObject
    {
        public DigiAdminModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateDigiAdminCommand, UpdateDigiAdminRequest>();
    }

    public class UpdateDigiAdminDto : IMapFrom<UpdateDigiAdminResponse>
    {
        public DigiAdminModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateDigiAdminResponse, UpdateDigiAdminDto>();
    }


    public class UpdateDigiAdminResponse : BaseResponseObject
    {
        public DigiAdminModel Properties { get; set; }
    }


    public class UpdateDigiAdminCommand : IRequest<UpdateDigiAdminDto>
    {
        public DigiAdminModel Properties { get; set; }


        public class UpdateDigiAdminCommandHandler : IRequestHandler<UpdateDigiAdminCommand, UpdateDigiAdminDto>
        {
            private readonly IDigiAdminsApi _digiAdminsApi;
            private readonly IMapper _mapper;

            public UpdateDigiAdminCommandHandler(IDigiAdminsApi digiAdminsApi, IMapper mapper)
            {
                _digiAdminsApi = digiAdminsApi;
                _mapper = mapper;
            }

            public async Task<UpdateDigiAdminDto> Handle(UpdateDigiAdminCommand request, CancellationToken cancellationToken)
            {

                var response = await _digiAdminsApi.CreateItem<UpdateDigiAdminResponse, UpdateDigiAdminRequest>(_mapper.Map<UpdateDigiAdminRequest>(request));
                return _mapper.Map<UpdateDigiAdminDto>(response);

            }

        }
    }
}
