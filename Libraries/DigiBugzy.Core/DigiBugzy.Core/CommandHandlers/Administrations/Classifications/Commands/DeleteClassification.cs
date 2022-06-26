

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Classifications.Commands
{
    public class DeleteClassificationRequest : IMapFrom<DeleteClassificationCommand>, IRequestObject
    {
        public ClassificationModel Model { get; set; }

        public StandardFilter Filter { get; set; } = new();

        public void Mapping(Profile profile) => profile.CreateMap<DeleteClassificationCommand, DeleteClassificationRequest>();
    }

    public class DeleteClassificationDto : IMapFrom<DeleteClassificationResponse>
    {
        public ClassificationModel Model { get; set; }

        public StandardFilter Filter { get; set; } = new();

        public void Mapping(Profile profile) => profile.CreateMap<DeleteClassificationResponse, DeleteClassificationDto>();
    }


    public class DeleteClassificationResponse : BaseResponseObject
    {
        public ClassificationModel Model { get; set; }
    }


    public class DeleteClassificationCommand : IRequest<DeleteClassificationDto>
    {
        public ClassificationModel Model { get; set; }


        public class DeleteClassificationCommandHandler : IRequestHandler<DeleteClassificationCommand, DeleteClassificationDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public DeleteClassificationCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<DeleteClassificationDto> Handle(DeleteClassificationCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<DeleteClassificationResponse, DeleteClassificationRequest>(_mapper.Map<DeleteClassificationRequest>(request));
                return _mapper.Map<DeleteClassificationDto>(response);

            }

        }
    }
}
