
namespace DigiBugzy.Core.Domain.Finance.Ledgers
{
    [Table(name: nameof(Ledger), Schema = DatabaseConstants.Schemas.Finance)]
    public class Ledger: BaseAdministrationEntity
    {

        public int LedgerTypeId { get; set; }

        public int LedgerClassificationId { get; set; }

        [ForeignKey(nameof(LedgerTypeId))]
        public LedgerType AccountType { get; set; } = new();

        [ForeignKey(nameof(LedgerClassificationId))]
        public LedgerClassification AccountClassification { get; set; } = new();

    }
}
