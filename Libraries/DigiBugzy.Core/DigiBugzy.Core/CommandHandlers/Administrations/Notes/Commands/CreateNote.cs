
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Notes.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Notes.Commands
{
    public class CreateNoteRequest : IMapFrom<CreateNoteCommand>, IRequestObject
    {
        public NoteModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateNoteCommand, CreateNoteRequest>();
    }

    public class CreateNoteDto : IMapFrom<CreateNoteResponse>
    {
        public NoteModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<CreateNoteResponse, CreateNoteDto>();
    }


    public class CreateNoteResponse : BaseResponseObject
    {
        public NoteModel Properties { get; set; }
    }


    public class CreateNoteCommand : IRequest<CreateNoteDto>
    {
        public NoteModel Properties { get; set; }


        public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, CreateNoteDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public CreateNoteCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<CreateNoteDto> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<CreateNoteResponse, CreateNoteRequest>(_mapper.Map<CreateNoteRequest>(request));
                return _mapper.Map<CreateNoteDto>(response);

            }

        }
    }
}
