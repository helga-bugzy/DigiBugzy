
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Notes.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Notes.Commands
{

    public class UpdateNoteRequest : IMapFrom<UpdateNoteCommand>, IRequestObject
    {
        public NoteModel Properties { get; set; }
        

        public void Mapping(Profile profile) => profile.CreateMap<UpdateNoteCommand, UpdateNoteRequest>();
    }

    public class UpdateNoteDto : IMapFrom<UpdateNoteResponse>
    {
        public NoteModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<UpdateNoteResponse, UpdateNoteDto>();
    }


    public class UpdateNoteResponse : BaseResponseObject
    {
        public NoteModel Properties { get; set; }
    }


    public class UpdateNoteCommand : IRequest<UpdateNoteDto>
    {
        public NoteModel Properties { get; set; }


        public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, UpdateNoteDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public UpdateNoteCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<UpdateNoteDto> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<UpdateNoteResponse, UpdateNoteRequest>(_mapper.Map<UpdateNoteRequest>(request));
                return _mapper.Map<UpdateNoteDto>(response);

            }

        }
    }
}
