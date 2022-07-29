

namespace DigiBugzy.Data.Migrations
{
    public class BaseEntityCreator: IDisposable
    {

        public enum FieldTypes { 
            AsInt32,
            AsString,
            AsDateTime,
            AsBinary
        }

        public enum MappingTypes {
            Product,
            Category,
            BusinessEntity,
            CustomField,
            Project,
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
                .WithColumn(nameof(BaseEntity.CreatedOn)).AsDateTime();

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
                .WithColumn(nameof(BaseEntity.CreatedOn)).AsDateTime();

            Migrator.Alter.Table(TableName)
                .InSchema(SchemaName)
                .AddColumn(nameof(BaseAdministrationEntity.Name)).AsString()
                .AddColumn(nameof(BaseAdministrationEntity.Description)).AsString();
        }

        public void CreateBaseAdministrationEntity()
        {
            CreateBaseEntity();
            Migrator.Alter.Table(TableName)
                .InSchema(SchemaName)
                .AddColumn(nameof(BaseAdministrationEntity.Name)).AsString()
                .AddColumn(nameof(BaseAdministrationEntity.Description)).AsString();
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
                            .AddColumn(fieldName).AsDateTime().Nullable();
                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsDateTime().NotNullable();
                    }
                    
                    break;
                case FieldTypes.AsBinary:
                    if (isNullable)
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsBinary().Nullable();
                    }
                    else
                    {
                        Migrator.Alter.Table(TableName).InSchema(SchemaName)
                            .AddColumn(fieldName).AsBinary().NotNullable();
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
        }

        public void AddMapping(MappingTypes mappingType, string fromSchemaName = "", string toSchemaName = "")
        {
            var mainTableName = Enum.GetName(typeof(MappingTypes), mappingType);
            var columnName = $"{mainTableName}Id";
            AddColumn(columnName);
            AddForeignKey(TableName, string.IsNullOrEmpty(mainTableName) ? "" : mainTableName, columnName, fromSchemaName, toSchemaName);
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
