
using System.ComponentModel;

namespace DigiBugzy.Core.ViewModels.Catalog
{
    public class ProductGridViewModel
    {
        [DisplayName("No")]
        public int Id { get; set; }

        [DisplayName("Photo")]
        public byte[] Image { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public int? ParentId { get; set; }

        [DisplayName("Parent Product")]
        public string ParentName { get; set; }

        [DisplayName("Total In Stock")]
        public double TotalInStock { get; set; }

        [DisplayName("Qty Reserved")]
        public double QuantityReserved { get; set; }

        
        [DisplayName("Qty On Order")]
        public double QuantityOnOrder { get; set; }

        [DisplayName("Total Value")]
        public double TotalValue { get; set; }


        public List<ProductGridViewModel> SubProducts { get; set; }
    }
}
