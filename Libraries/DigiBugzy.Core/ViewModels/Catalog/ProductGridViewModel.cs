using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Core.ViewModels.Catalog
{
    public class ProductGridViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public bool IsActive { get; set; }

        public int? ParentId { get; set; }

        public string ParentName { get; set; }

        public List<ProductGridViewModel> SubProducts { get; set; }
    }
}
