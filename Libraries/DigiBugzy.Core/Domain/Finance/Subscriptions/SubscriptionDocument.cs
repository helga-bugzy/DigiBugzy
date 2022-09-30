

namespace DigiBugzy.Core.Domain.Finance.Subscriptions

{
    [Table(name: nameof(SubscriptionDocument), Schema = DatabaseConstants.Schemas.Project)]
    public class SubscriptionDocument : BaseDocumentEntity
    {
        [Required]
        public int SubscriptionId { get; set; }  

       

        [ForeignKey(nameof(SubscriptionId))]
        public Subscription Subscription { get; set; }    
    }
}
