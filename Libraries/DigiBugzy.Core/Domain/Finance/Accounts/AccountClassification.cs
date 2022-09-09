
using System.ComponentModel;
namespace DigiBugzy.Core.Domain.Finance.Accounts
{
    [Table(name: nameof(LedgerClassification), Schema = DatabaseConstants.Schemas.Finance)]
    [Description("Asset, etc")]
    public class LedgerClassification: BaseAdministrationEntity
    {
    }
}
