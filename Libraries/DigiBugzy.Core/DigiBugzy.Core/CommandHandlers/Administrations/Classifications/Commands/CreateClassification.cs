

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Classifications.Commands
{
    public class CreateClassificationRequest : IMapFrom<CreateClassificationCommand>, IRequestObject
    {
        public ClassificationModel Model { get; set; }

        public StandardFilter Filter { get; set; } = new();

        public void Mapping(Profile profile) => profile.CreateMap<CreateClassificationCommand, CreateClassificationRequest>();
    }

    public class CreateClassificationDto : IMapFrom<CreateClassificationResponse>
    {
        public ClassificationModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateClassificationResponse, CreateClassificationDto>();
    }


    public class CreateClassificationResponse : BaseResponseObject
    {
        public ClassificationModel Model { get; set; }
    }


    public class CreateClassificationCommand : IRequest<CreateClassificationDto>
    {
        public ClassificationModel Model { get; set; }


        public class CreateClassificationCommandHandler : IRequestHandler<CreateClassificationCommand, CreateClassificationDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateClassificationCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<CreateClassificationDto> Handle(CreateClassificationCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateClassificationResponse, CreateClassificationRequest>(_mapper.Map<CreateClassificationRequest>(request));
                return _mapper.Map<CreateClassificationDto>(response);

            }

        }
    }
}
