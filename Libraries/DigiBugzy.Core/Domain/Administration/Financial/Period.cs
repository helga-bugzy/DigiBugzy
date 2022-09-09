
namespace DigiBugzy.Core.Domain.Administration.Financial
{
    [Table(name:nameof(Period), Schema = Constants.DatabaseConstants.Schemas.Admin)]
    //day, year, month, terms, etc
    public class Period: BaseAdministrationEntity
    {
    }
}
