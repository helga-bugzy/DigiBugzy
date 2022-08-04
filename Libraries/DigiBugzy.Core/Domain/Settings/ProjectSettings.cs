﻿

namespace DigiBugzy.Core.Domain.Settings
{
    [Table(nameof(ProjectSettings), Schema = DatabaseConstants.Schemas.Settings)]
    public class ProjectSettings : BaseSettings
    {

        public bool AutomateCategoryMappings { get; set; }

        public bool AutomateFieldMappings { get; set; }

    }
}