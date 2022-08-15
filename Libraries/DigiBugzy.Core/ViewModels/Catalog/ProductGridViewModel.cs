
using System.ComponentModel;

namespace DigiBugzy.Core.ViewModels.Catalog
{
    public class ProductGridViewModel
    {
        [DisplayName("No")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Photo")]
        public byte[] Image { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public int? ParentId { get; set; }

        [DisplayName("Parent Product")]
        public string ParentName { get; set; }

        public List<ProductGridViewModel> SubProducts { get; set; }
    }
}
