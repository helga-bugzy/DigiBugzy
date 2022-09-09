#nullable enable
using DigiBugzy.Core.Domain.Finance.Accounts;
using DigiBugzy.Core.Domain.Finance.Assets;
using DigiBugzy.Core.Domain.Finance.Ledgers;

namespace DigiBugzy.Core.Domain.Finance.Subscriptions
{
    [Table(name: nameof(Subscription), Schema = DatabaseConstants.Schemas.Finance)]
    public class Subscription
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime InitialPeriodInMonths { get; set; }

        public DateTime CanBeCancelledOn { get; set; }

        public decimal LoanAmount { get; set; }

        public decimal InterestRate { get; set; }

        public decimal InterestTotal { get; set; }

        public decimal PremiumAmount { get; set; }

        
        public decimal PremiumAccountId { get; set; }

        public int SubscriptionTypeId { get; set; }

        public int SubscriptionClassificationId { get; set; }

        public int LedgerId { get; set; }

        public decimal? AssetId { get; set; }


        [ForeignKey(nameof(SubscriptionTypeId))]
        public SubscriptionType SubscriptionType {get;set; } = new();

        [ForeignKey(nameof(SubscriptionClassificationId))]
        public SubscriptionClassification SubscriptionClassification { get; set; } = new();

        [ForeignKey(nameof(PremiumAccountId))]
        public Account PremiumAccount { get; set; } = new();

        [ForeignKey(nameof(AssetId))]
        public Asset? Asset { get; set; }

        [ForeignKey(nameof(LedgerId))]
        public Ledger Ledget { get; set; } = new();
    }
}
