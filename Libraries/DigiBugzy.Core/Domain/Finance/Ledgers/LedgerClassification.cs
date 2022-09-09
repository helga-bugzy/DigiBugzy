
using System.ComponentModel;
namespace DigiBugzy.Core.Domain.Finance.Ledgers
{
    [Table(name: nameof(LedgerClassification), Schema = DatabaseConstants.Schemas.Finance)]
    [Description("Asset, etc")]
    public class LedgerClassification: BaseAdministrationEntity
    {
    }
}
