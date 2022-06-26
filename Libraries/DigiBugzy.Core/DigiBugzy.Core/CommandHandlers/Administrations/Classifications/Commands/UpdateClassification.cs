
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Classifications.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Classifications.Commands
{

    public class UpdateClassificationRequest : IMapFrom<UpdateClassificationCommand>, IRequestObject
    {
        public ClassificationModel Model { get; set; }

        public StandardFilter Filter { get; set; } = new();


        public void Mapping(Profile profile) => profile.CreateMap<UpdateClassificationCommand, UpdateClassificationRequest>();
    }

    public class UpdateClassificationDto : IMapFrom<UpdateClassificationResponse>
    {
        public ClassificationModel Model { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateClassificationResponse, UpdateClassificationDto>();
    }


    public class UpdateClassificationResponse : BaseResponseObject
    {
        public ClassificationModel Model { get; set; }
    }


    public class UpdateClassificationCommand : IRequest<UpdateClassificationDto>
    {
        public ClassificationModel Model { get; set; }


        public class UpdateClassificationCommandHandler : IRequestHandler<UpdateClassificationCommand, UpdateClassificationDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateClassificationCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateClassificationDto> Handle(UpdateClassificationCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateClassificationResponse, UpdateClassificationRequest>(_mapper.Map<UpdateClassificationRequest>(request));
                return _mapper.Map<UpdateClassificationDto>(response);

            }

        }
    }
}
