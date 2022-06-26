namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Notes.Models
{
    public class NoteModel : BaseAdminsProperties
    {
        public int ParentId { get; set; }

        public int ClassificationId { get; set; }

        public Classification Classification { get; set; }

        public Note Parent { get; set; }

        public List<Note> Children { get; set; }
    }
}
