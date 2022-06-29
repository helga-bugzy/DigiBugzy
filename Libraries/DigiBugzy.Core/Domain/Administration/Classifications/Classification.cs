

namespace DigiBugzy.Core.Domain.Administration.Classifications
{
    [Table(name: nameof(Classification), Schema = DatabaseConstants.Schemas.Admin)]
    public abstract class Classification: BaseAdministrationEntity
    {
    }
}
