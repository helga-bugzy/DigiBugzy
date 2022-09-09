
using DigiBugzy.Core.Domain.BusinessEntities;

namespace DigiBugzy.Core.Domain.Finance.Accounts
{
    [Table(name: nameof(Account), Schema = DatabaseConstants.Schemas.Finance)]
    public class Account: BaseAdministrationEntity
    {
        public int BusinessEntityId { get; set; }

        public int AccountTypeId { get; set; }

        public int AccountClassificationId { get; set; }

        [ForeignKey(nameof(AccountTypeId))]
        public LedgerType AccountType { get; set; } = new();

        [ForeignKey(nameof(AccountClassificationId))]
        public LedgerClassification AccountClassification { get; set; } = new();

        [ForeignKey(nameof(BusinessEntityId))]
        public BusinessEntity BusinessEntity { get; set; }
    }
}
