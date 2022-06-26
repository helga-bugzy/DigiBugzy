
namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.DigiAdmins.Commands
{
     public class DeleteDigiAdminRequest : IMapFrom<DeleteDigiAdminCommand>, IRequestObject
    {
        public DigiAdminModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteDigiAdminCommand, DeleteDigiAdminRequest>();
    }

    public class DeleteDigiAdminDto : IMapFrom<DeleteDigiAdminResponse>
    {
        public DigiAdminModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteDigiAdminResponse, DeleteDigiAdminDto>();
    }


    public class DeleteDigiAdminResponse : BaseResponseObject
    {
        public DigiAdminModel Properties { get; set; }
    }    

   
    public class DeleteDigiAdminCommand : IRequest<DeleteDigiAdminDto>
    {
        public DigiAdminModel Properties { get; set; }


        public class DeleteDigiAdminCommandHandler : IRequestHandler<DeleteDigiAdminCommand, DeleteDigiAdminDto>
        {
            private readonly IDigiAdminsApi _digiAdminsApi;
            private readonly IMapper _mapper;

            public DeleteDigiAdminCommandHandler(IDigiAdminsApi digiAdminsApi, IMapper mapper)
            {
                _digiAdminsApi = digiAdminsApi;
                _mapper = mapper;
            }

            public async Task<DeleteDigiAdminDto> Handle(DeleteDigiAdminCommand request, CancellationToken cancellationToken)
            {

                var response = await _digiAdminsApi.DeleteItem<DeleteDigiAdminResponse, DeleteDigiAdminRequest>(_mapper.Map<DeleteDigiAdminRequest>(request));
                return _mapper.Map<DeleteDigiAdminDto>(response);

            }

        }
    }
}
