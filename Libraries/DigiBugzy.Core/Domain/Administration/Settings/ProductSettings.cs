
namespace DigiBugzy.Core.Domain.Administration.Settings
{
    [Table(nameof(ProductSettings), Schema = DatabaseConstants.Schemas.Settings)]
    public class ProductSettings: BaseSettings
    {
        public bool AutomateCategoryMappings { get; set; }

        public bool AutomateFieldMappings { get; set; }

        
        
    }
}
