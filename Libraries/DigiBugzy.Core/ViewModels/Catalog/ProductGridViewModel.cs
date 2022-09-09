
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

        /// <summary>
        /// Total physical in stock
        /// </summary>
        [DisplayName("Total In Stock")]
        public double TotalInStock { get; set; }

        /// <summary>
        /// When reserving for a project this project part in planning but not executed yet
        /// </summary>
        [DisplayName("Reserved")]
        public double QuantityReserved { get; set; }

        /// <summary>
        /// When stock is on order but not received yet
        /// </summary>

        [DisplayName("On Order")]
        public double QuantityOnOrder { get; set; }

        [DisplayName("Value")]
        public double TotalValue { get; set; }


        public List<ProductGridViewModel> SubProducts { get; set; }
    }
}
