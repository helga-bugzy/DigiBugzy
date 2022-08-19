

namespace DigiBugzy.Core.Domain.BusinessEntities
{

    [Table(name: nameof(BusinessEntityCategory), Schema = DatabaseConstants.Schemas.ContactBase)]
    public class BusinessEntityCategory
    {

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
