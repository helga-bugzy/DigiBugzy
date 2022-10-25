using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Data.Common.xBaseObjects
{
    public class ProjectPrintingFilter: StandardFilter
    {
        public int ProjectId { get; set; }

        public int ProjectSectionId { get; set; }

        public int ProjectSectionPartId { get; set; }


        //For userinterface use
        public Project Project { get; set; }

        public ProjectSection Section { get; set; }

        public ProjectSectionPart Part { get; set; }
    }
}
