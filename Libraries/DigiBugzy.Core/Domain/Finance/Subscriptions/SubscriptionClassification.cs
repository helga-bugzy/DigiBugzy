using System.ComponentModel;

namespace DigiBugzy.Core.Domain.Finance.Subscriptions
{
    [Table(name: nameof(SubscriptionClassification), Schema = DatabaseConstants.Schemas.Finance)]
    [Description("Yearly monthly etc")]
    public class SubscriptionClassification: BaseAdministrationEntity
    {
        
    }
}
