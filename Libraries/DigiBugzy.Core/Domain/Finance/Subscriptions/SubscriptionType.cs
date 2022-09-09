using System.ComponentModel;

namespace DigiBugzy.Core.Domain.Finance.Subscriptions
{
    [Table(name: nameof(SubscriptionType), Schema = DatabaseConstants.Schemas.Finance)]
    [Description("")]
    public class SubscriptionType : BaseEntity
    {
    }
}
