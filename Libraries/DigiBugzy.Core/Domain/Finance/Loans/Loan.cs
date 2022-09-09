#nullable enable
using DigiBugzy.Core.Domain.Finance.Accounts;
using DigiBugzy.Core.Domain.Finance.Assets;
using DigiBugzy.Core.Domain.Finance.Ledgers;

namespace DigiBugzy.Core.Domain.Finance.Loans
{
    [Table(name: nameof(Loan), Schema = DatabaseConstants.Schemas.Finance)]
    public class Loan
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal LoanAmount { get; set; }

        public decimal InterestRate { get; set; }

        public decimal InterestTotal { get; set; }

        public decimal PremiumAmount { get; set; }

        
        public decimal PremiumAccountId { get; set; }

        public int LoanTypeId { get; set; }

        public int LoanClassificationId { get; set; }

        public int LedgerId { get; set; }

        public decimal? AssetId { get; set; }


        [ForeignKey(nameof(LoanTypeId))]
        public LoanType LoanType {get;set; } = new();

        [ForeignKey(nameof(LoanClassificationId))]
        public LoanClassification LoanClassification { get; set; } = new();

        [ForeignKey(nameof(PremiumAccountId))]
        public Account PremiumAccount { get; set; } = new();

        [ForeignKey(nameof(AssetId))]
        public Asset? Asset { get; set; }

        [ForeignKey(nameof(LedgerId))]
        public Ledger Ledget { get; set; } = new();
    }
}
