using System.ComponentModel;

namespace DigiBugzy.Core.Domain.Finance.Loans
{
    [Table(name: nameof(LoanClassification), Schema = DatabaseConstants.Schemas.Finance)]
    [Description("Long term, short term")]
    public class LoanClassification : BaseAdministrationEntity
    {
        
    }
}
