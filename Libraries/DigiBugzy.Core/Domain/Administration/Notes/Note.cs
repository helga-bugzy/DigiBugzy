
namespace DigiBugzy.Core.Domain.Administration.Notes
{
    [Table(name: nameof(Note), Schema = DatabaseConstants.Schemas.Admin)]
    public abstract class Note: BaseAdministrationEntity
    {
       public int ClassificationId { get; set; }

       [ForeignKey(nameof(ClassificationId))]
       public Classification Classification { get; set; }
    }
}
