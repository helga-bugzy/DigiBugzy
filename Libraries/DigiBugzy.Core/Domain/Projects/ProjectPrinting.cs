

using DigiBugzy.Core.Domain.Administration.Printing;

namespace DigiBugzy.Core.Domain.Projects
{
    /// <summary>
    /// Class for 3D printing informmation
    /// </summary>
    [Table(name: nameof(ProjectPrinting), Schema = DatabaseConstants.Schemas.Project)]
    public class ProjectPrinting: BaseProjectSublementEntity
    {
        

        public int PrinterId { get; set; }

        
        public decimal Infil { get; set; }

        public decimal WallThickness { get; set; }

        public decimal FilamentUsedMeter { get; set; }

        public decimal FilamentUsedGram { get; set; }

        public int ResolutionId { get; set; }


        #region Required

        public int RequiredQuantity { get; set; }

        public int RequiredFilamentTypeId { get; set; }

        public int RequiredFilamentColorId { get; set; }

        #endregion

        
        #region Actuals

        public int? ActualQuantity { get; set; }

        public int? ActualFilamentTypeId { get; set; }

        public int ActualFilamentColorId { get; set; }

        #endregion



        #region Files

        public string StlFileName { get; set; }

        public bool IsGCodeMade { get; set; }


        public byte[] GCodeFile { get; set; }

        public byte[] StlFile { get; set; }

        public byte[] CadFile { get; set; }

        public byte[] Picture { get; set; }

        #endregion

        #region Printing

        
        public string EstimatedPrintTime { get; set; }

        public string ActualPrintTime { get; set; }

        #endregion

        #region Objects

        [ForeignKey(nameof(PrinterId))]
        public ThreeDPrinter Printer { get; set; } = new();

        [ForeignKey(nameof(ResolutionId))]
        public ThreeDResolution Resolution { get; set; } = new();

        [ForeignKey(nameof(RequiredFilamentTypeId))]
        public ThreeDFilamentType RequiredFilamentType { get; set; }

        [ForeignKey(nameof(ActualFilamentTypeId))]
        public ThreeDFilamentType ActualFilamentType { get; set; }

        [ForeignKey(nameof(RequiredFilamentColorId))]
        public ThreeDFilamentColor RequiredFilamentColor { get; set; }

        [ForeignKey(nameof(ActualFilamentColorId))]
        public ThreeDFilamentColor ActualFilamentColor { get; set; }

        #endregion
    }
}
