using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Data.Common.xBaseObjects.FilterObjects
{
    public class ProjectDocumentFilter: StandardFilter
    {
        public int ProjectId { get; set; }

        public int ProjectSectionId { get; set; }

        public int ProjectSectionPartId { get; set; }

        public bool Only3DPrintingDocument { get; set; }

        public bool OnlySpecifications { get; set; }

        public bool OnlyPlans { get; set; }

        public bool OnlyInstructions { get; set; }


        public bool IncludeProjectSearch { get; set; } = true;

        public bool IncludeSectionSearch { get; set; }

        public bool IncludePartSearch { get; set; }

        


        //For userinterface use
        public Project Project { get; set; }

        public ProjectSection Section { get; set; }

        public ProjectSectionPart Part { get; set; }

    }
}
