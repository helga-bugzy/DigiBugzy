
using DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Notes.Models;

namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Notes.Commands
{
    public class DeleteNoteRequest : IMapFrom<DeleteNoteCommand>, IRequestObject
    {
        public NoteModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteNoteCommand, DeleteNoteRequest>();
    }

    public class DeleteNoteDto : IMapFrom<DeleteNoteResponse>
    {
        public NoteModel Properties { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<DeleteNoteResponse, DeleteNoteDto>();
    }


    public class DeleteNoteResponse : BaseResponseObject
    {
        public NoteModel Properties { get; set; }
    }


    public class DeleteNoteCommand : IRequest<DeleteNoteDto>
    {
        public NoteModel Properties { get; set; }


        public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, DeleteNoteDto>
        {
            private readonly IApiHandler _apiHandler;
            private readonly IMapper _mapper;

            public DeleteNoteCommandHandler(IApiHandler apiHandler, IMapper mapper)
            {
                _apiHandler = apiHandler;
                _mapper = mapper;
            }

            public async Task<DeleteNoteDto> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
            {

                var response = await _apiHandler.CreateItem<DeleteNoteResponse, DeleteNoteRequest>(_mapper.Map<DeleteNoteRequest>(request));
                return _mapper.Map<DeleteNoteDto>(response);

            }

        }
    }
}
