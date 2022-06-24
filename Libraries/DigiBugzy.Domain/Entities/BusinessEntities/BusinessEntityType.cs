

namespace DigiBugzy.Domain.Entities.BusinessEntities
{
    [Table(name: nameof(BusinessEntityType), Schema = DatabaseConstants.Schemas.ContactBase)]
    public abstract class BusinessEntityType : BaseAdministrationEntity
    {

    }
}
