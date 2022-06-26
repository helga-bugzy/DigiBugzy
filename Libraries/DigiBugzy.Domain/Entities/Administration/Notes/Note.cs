﻿
namespace DigiBugzy.Domain.Entities.Administration.Notes
{
    [Table(name: nameof(Note), Schema = DatabaseConstants.Schemas.Admin)]
    public abstract class Note: BaseAdministrationEntity
    {
       public int ClassificationId { get; set; }

       [ForeignKey(nameof(Classification))]
       public Classification Classification { get; set; }
    }
}