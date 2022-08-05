
namespace DigiBugzy.Core.ViewModels.Administration
{
    public class CategoryGridViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public string ParentName { get; set; }
    }
}
