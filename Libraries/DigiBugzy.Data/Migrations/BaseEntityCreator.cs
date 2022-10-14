

using DigiBugzy.Core.Domain.Settings;

namespace DigiBugzy.Data.Migrations
{
    public class BaseEntityCreator: IDisposable
    {

        public enum FieldTypes { 
            AsInt32,
            AsInt64,
            AsString,
            AsDateTime,
            AsBinary,
            AsBoolean,
            AsDecimal,
            AsDouble,
        }

        public enum MappingTypes {
            Asset, 
            Product,
            Category,
            BusinessEntity,
            CustomField,
            Project,
            ProjectPart,
            ProjectSection,
            Classification,
            DigiAdmin
        }


        private bool disposedValue;

        public string TableName { get; set; } = string.Empty;
        public string SchemaName { get; set; }
        public MigrationBase Migrator { get; private set; }

        public BaseEntityCreator(string tableName, string schemaName, MigrationBase migrator)
        {
            TableName = tableName;
            SchemaName = schemaName;
            Migrator = migrator;
        }

        public BaseEntityCreator(string schemaName, MigrationBase migrator)
        {
            
            SchemaName = schemaName;
            Migrator = migrator;
        }


        public void StartNewTable(string tableName, string schemaName)
        {
            TableName = tableName;
            SchemaName = schemaName;
        }

        public void StartNewTable(string tableName)
        {
            TableName = tableName;
        }

        public void CreateBaseEntity()
        {
            try
            {
                Migrator.Create.Table(TableName)
                .InSchema(SchemaName)
                .WithColumn(nameof(BaseEntity.Id)).AsInt32().PrimaryKey().Identity()
                .WithColumn(nameof(BaseEntity.IsActive)).AsBoolean()
                .WithColumn(nameof(BaseEntity.IsDeleted)).AsBoolean()
                .WithColumn(nameof(BaseEntity.CreatedOn)).AsDateTime2();

                AddMapping(MappingTypes.DigiAdmin, toSchemaName: DatabaseConstants.Schemas.Admin);
            }
            catch (Exception)
            {
                //Already exist just do nothing
            }
        }

        public void CreateBaseSettingsEntity()
        {
            try
            {
                Migrator.Create.Table(TableName)
                    .InSchema(SchemaName)
                    .WithColumn(nameof(BaseSettings.Id)).AsInt32().PrimaryKey().Identity()
                    .WithColumn(nameof(BaseSettings.AllowSettingOverrides)).AsBoolean()
                    .WithColumn(nameof(BaseSettings.ApplyAutomationDown)).AsBoolean()
                    .WithColumn(nameof(BaseSettings.ApplyAutomationUp)).AsBoolean()
                    .WithColumn(nameof(BaseSettings.ImageHeight)).AsInt32()
                    .WithColumn(nameof(BaseSettings.ImageWidth)).AsInt32()
                    .WithColumn(nameof(BaseSettings.ThumbHeight)).AsInt32()
                    .WithColumn(nameof(BaseSettings.ThumbWidth)).AsInt32(); 

                AddMapping(MappingTypes.DigiAdmin, toSchemaName: DatabaseConstants.Schemas.Admin);
            }
            catch (Exception)
            {
                //Already exist just do nothing
            }
        }

        public void CreateBaseDigiAdminEntity()
        {
            Migrator.Create.Table(TableName)
                .InSchema(SchemaName)
                .WithColumn(nameof(BaseEntity.Id)).AsInt32().PrimaryKey().Identity()
                .WithColumn(nameof(BaseEntity.IsActive)).AsBoolean()
                .WithColumn(nameof(BaseEntity.IsDeleted)).AsBoolean()
                .WithColumn(nameof(BaseEntity.CreatedOn)).AsDateTime2();

            Migrator.Alter.Table(TableName)
                .InSchema(SchemaName)
                .AddColumn(nameof(BaseAdministrationEntity.Name)).AsString().Nullable()
                .AddColumn(nameof(BaseAdministrationEntity.Description)).AsString().Nullable();
        }

        public void CreateBaseAdministrationEntity()
        {
            CreateBaseEntity();
            Migrator.Alter.Table(TableName)
                .InSchema(SchemaName)
                .AddColumn(nameof(BaseAdministrationEntity.Name)).AsString().Nullable()
                .AddColumn(nameof(BaseAdministrationEntity.Description)).AsString().Nullable();
        }

        public void CreateBaseProjectSublementEntity()
        {
            CreateBaseAdministrationEntity();
            Migrator.Alter.Table(TableName)
                .InSchema(SchemaName)
                .AddColumn(nameof(BaseProjectSublementEntity.ProjectId)).AsInt32().NotNullable()
                .AddColumn(nameof(BaseProjectSublementEntity.ProjectSectionId)).AsInt32().Nullable()
                .AddColumn(nameof(BaseProjectSublementEntity.ProjectSectionPartId)).AsInt32().Nullable();

            AddForeignKey(TableName, nameof(Project), nameof(BaseProjectSublementEntity.ProjectId), SchemaName, SchemaName);
            AddForeignKey(TableName, nameof(ProjectSection), nameof(BaseProjectSublementEntity.ProjectSectionId), SchemaName, SchemaName);
            AddForeignKey(TableName, nameof(ProjectSectionPart), nameof(BaseProjectSublementEntity.ProjectSectionPartId), SchemaName, SchemaName);

        }

        public void CreateBaseDocumentEntity()
        {
            CreateBaseAdministrationEntity();
            Migrator.Alter.Table(TableName)
                .InSchema(SchemaName)
                .AddColumn(nameof(BaseDocumentEntity.DocumentTypeId)).AsInt32().NotNullable()
                .AddColumn(nameof(BaseDocumentEntity.DocumentFileTypeId)).AsInt32().NotNullable()
                .AddColumn(nameof(BaseDocumentEntity.DocumentData)).AsBinary().NotNullable();

            AddForeignKey(
                toTable: nameof(DocumentType),
                toSchemaName: DatabaseConstants.Schemas.Admin,
                fromTable: TableName,
                fromFieldName: nameof(BaseDocumentEntity.DocumentTypeId), 
                fromSchemaName: SchemaName);

            AddForeignKey(
                toTable: nameof(DocumentFileType),
                toSchemaName: DatabaseConstants.Schemas.Admin,
                fromTable: TableName,
                fromFieldName: nameof(BaseDocumentEntity.DocumentFileTypeId),
                fromSchemaName: SchemaName);
        }


        

        #region Helper Methods

        public void AddColumn(string fieldName,FieldTypes fieldType = FieldTypes.AsInt32, bool isNullable = false)
        {
                      
            switch (fieldType)
            {
                case FieldTypes.AsInt32:
                    if(isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                        .AddColumn(fieldName).AsInt32().Nullable();

                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsInt32().NotNullable();
                    }
                    break;
                case FieldTypes.AsInt64:
                    if (isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsInt64().Nullable();

                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsInt64().NotNullable();
                    }
                    break;
                case FieldTypes.AsString:

                    if (isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsString().Nullable();
                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsString().NotNullable();
                    }
                    break;
                case FieldTypes.AsDateTime:
                    if (isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsDateTime2().Nullable();
                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsDateTime2().NotNullable();
                    }
                    
                    break;
                case FieldTypes.AsBinary:
                    if (isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsBinary(1000000000).Nullable();
                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsBinary(1000000000).NotNullable();
                    }

                    break;
                case FieldTypes.AsBoolean:
                    if (isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsBoolean().Nullable();
                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsBoolean().NotNullable();
                    }
                    break;
                case FieldTypes.AsDecimal:
                    if (isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsDecimal().Nullable(); 
                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsDecimal().NotNullable().WithDefaultValue(0); 
                    }

                    break;
                case FieldTypes.AsDouble:
                    if (isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsDouble().Nullable();
                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsDouble().NotNullable().WithDefaultValue(0);
                    }

                    break;
            }
        }

        public void AddForeignKey(string fromTable, string toTable, string fromFieldName, string fromSchemaName = "", string toSchemaName = "")
        {
            if (string.IsNullOrEmpty(fromSchemaName)) fromSchemaName = SchemaName;
            if (string.IsNullOrEmpty(toSchemaName)) toSchemaName = SchemaName;

            Migrator.Create.ForeignKey($"FK_{fromTable}_{toTable}_{fromFieldName}")
                //From schema.table.field
                .FromTable(fromTable)
                .InSchema(fromSchemaName)
                .ForeignColumn(fromFieldName)
                
                
                //To schema.table.id
                .ToTable(toTable)
                .InSchema(toSchemaName)
                .PrimaryColumn(nameof(BaseEntity.Id));
                //.OnDeleteOrUpdate(Rule.SetDefault);
        }

        public void AddMapping(MappingTypes mappingType, string fromSchemaName = "", string toSchemaName = "")
        {
            var mainTableName = Enum.GetName(typeof(MappingTypes), mappingType);
            var columnName = $"{mainTableName}Id";
            AddColumn(columnName);
            AddForeignKey(TableName, string.IsNullOrEmpty(mainTableName) ? "" : mainTableName, columnName, fromSchemaName, toSchemaName);
        }

        public void AddMapping(MappingTypes mappingType, string fromColumnName, string fromSchemaName = "", string toSchemaName = "")
        {
            var mainTableName = Enum.GetName(typeof(MappingTypes), mappingType);
            var columnName = fromColumnName;
            AddColumn(columnName);
            AddForeignKey(TableName, string.IsNullOrEmpty(mainTableName) ? "" : mainTableName, columnName, fromSchemaName, toSchemaName);
        }

        public void DeleteTable()
        {
            
        }


        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BaseEntityCreator()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
