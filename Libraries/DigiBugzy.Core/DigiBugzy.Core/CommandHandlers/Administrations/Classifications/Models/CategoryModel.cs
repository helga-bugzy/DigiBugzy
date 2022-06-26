namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.Categories.Models
{
    public class NoteModel : BaseAdminsProperties
    {
        public int ParentId { get; set; }

        public int ClassificationId { get; set; }

        public Classification Classification { get; set; }

        public Category Parent { get; set; }

        public List<Category> Children { get; set; }
    }
}
