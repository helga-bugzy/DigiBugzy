

namespace DigiBugzy.ApplicationLayer.Migrations
{
    public class BaseEntityCreator: IDisposable
    {

        public enum FieldTypes { 
            AsInt64,
            AsString,
            AsDateTime
        }

        public enum MappingTypes {
            Product,
            Category,
            BusinessEntity,
            CustomField,
            Project,
            Classification
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
            Migrator.Create.Table(TableName)
                .InSchema(SchemaName)
                .WithColumn(nameof(BaseEntity.Id)).AsInt64().PrimaryKey().Identity()
                .WithColumn(nameof(BaseEntity.IsActive)).AsBoolean()
                .WithColumn(nameof(BaseEntity.IsDeleted)).AsBoolean()
                .WithColumn(nameof(BaseEntity.CreatedOn)).AsDateTime();
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

        public void AddColumn(string fieldName,FieldTypes fieldType = FieldTypes.AsInt64)
        {
                      
            switch (fieldType)
            {
                case FieldTypes.AsInt64:
                    Migrator.Alter.Table(TableName).InSchema(SchemaName)
                        .AddColumn(fieldName).AsInt64();
                    break;
                case FieldTypes.AsString:
                    Migrator.Alter.Table(TableName).InSchema(SchemaName)
                        .AddColumn(fieldName).AsString();
                    break;
                case FieldTypes.AsDateTime:
                    Migrator.Alter.Table(TableName).InSchema(SchemaName)
                        .AddColumn(fieldName).AsDateTime();
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
