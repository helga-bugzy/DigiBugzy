﻿

namespace DigiBugzy.Domain.Entities.Administration.CustomFields
{
    [Table(name: nameof(CustomFieldType), Schema = DatabaseConstants.Schemas.Admin)]
    public abstract class CustomFieldType : BaseAdministrationEntity
    {

    }
}