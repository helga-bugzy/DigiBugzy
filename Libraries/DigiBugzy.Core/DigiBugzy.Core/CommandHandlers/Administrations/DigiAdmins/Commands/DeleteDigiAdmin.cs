
namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.DigiAdmins.Commands
{
     public class DeleteDigiAdminRequest : IMapFrom<DeleteDigiAdminCommand>, IRequestObject
    {
        public DigiAdminModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteDigiAdminCommand, DeleteDigiAdminRequest>();
    }

    public class DeleteDigiAdminDto : IMapFrom<DeleteDigiAdminResponse>
    {
        public DigiAdminModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteDigiAdminResponse, DeleteDigiAdminDto>();
    }


    public class DeleteDigiAdminResponse : BaseResponseObject
    {
        public DigiAdminModel Model { get; set; }
    }    

   
    public class DeleteDigiAdminCommand : IRequest<DeleteDigiAdminDto>
    {
        public DigiAdminModel Model { get; set; }


        public class DeleteDigiAdminCommandHandler : IRequestHandler<DeleteDigiAdminCommand, DeleteDigiAdminDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public DeleteDigiAdminCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<DeleteDigiAdminDto> Handle(DeleteDigiAdminCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.DeleteItem<DeleteDigiAdminResponse, DeleteDigiAdminRequest>(_mapper.Map<DeleteDigiAdminRequest>(request));
                return _mapper.Map<DeleteDigiAdminDto>(response);

            }

        }
    }
}
