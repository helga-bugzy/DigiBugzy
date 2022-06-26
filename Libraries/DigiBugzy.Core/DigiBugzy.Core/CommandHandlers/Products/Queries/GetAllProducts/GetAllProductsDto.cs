using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.ApplicationLayer.Sections.Products.Queries.GetAllProducts
{
    public class GetAllProductsDto: IMapFrom<GetAllProductsResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BugzerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetAllProductsResponse, GetAllProductsDto>();
        }
    }
}
