using System.ComponentModel;

namespace DigiBugzy.Core.Domain.Finance.Loans
{
    [Table(name: nameof(LoanType), Schema = DatabaseConstants.Schemas.Finance)]
    [Description("Asset Finance, home loan, credit card, lease, etc")]
    public class LoanType : BaseEntity
    {
    }
}
