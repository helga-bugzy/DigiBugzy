using System.ComponentModel;

namespace DigiBugzy.Core.Domain.Finance.Accounts
{
    [Table(name: nameof(LedgerType), Schema = DatabaseConstants.Schemas.Finance)]
    [Description("Income, expenses")]
    public class LedgerType: BaseAdministrationEntity
    {
    }
}
