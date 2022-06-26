﻿namespace DigiBugzy.Domain.Entities.Administration.CustomFields
{
    [Table(name: nameof(CustomFieldValue), Schema = DatabaseConstants.Schemas.Admin)]
    public abstract class CustomFieldValue : BaseEntity
    {
        [Required]
        public int CustomFieldId { get; set; }
        
        public string Value { get; set; }

        [ForeignKey(nameof(CustomFieldId))]
        public CustomField CustomField { get; set; }

    }
}