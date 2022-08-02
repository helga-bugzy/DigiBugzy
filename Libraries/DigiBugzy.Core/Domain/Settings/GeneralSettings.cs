

namespace DigiBugzy.Core.Domain.Settings
{
    [Table(nameof(GeneralSettings), Schema = DatabaseConstants.Schemas.Settings)]
    public class GeneralSettings: BaseSettings
    {
    }
}
