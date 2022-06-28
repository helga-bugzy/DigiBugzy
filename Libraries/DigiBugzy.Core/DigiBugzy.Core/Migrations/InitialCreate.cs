
namespace DigiBugzy.ApplicationLayer.Migrations
{
    [Migration(001)]
    public class InitialCreate: Migration
    {
        #region Properties

        private string _currentTableName = string.Empty;

        private string _currentSchemaName = string.Empty;        


        #endregion

        public override void Up()
        {
            CreateSchemas();
            CreateAdministrationTables();

            CreateContactBaseTables();
            CreateCatalogTables();
            CreateProjectsTables();            

        }

        public override void Down()
        {
            //TODODelete.Table("Log");
        }

        #region Helper Methods 

        /// <summary>
        /// Creates all the schemas as located in relevant contstants class
        /// </summary>
        private void CreateSchemas()
        {
            var schemas = ClassHelpers.GetConstants(typeof(DatabaseConstants.Schemas));
            foreach(var schema in schemas)
            {
                Create.Schema(schema.Name);
            }
        }

        /// <summary>
        /// Creates administration tables
        /// </summary>
        private void CreateAdministrationTables()
        {
            
            _currentSchemaName = DatabaseConstants.Schemas.Admin;

            using(var creatory = new BaseEntityCreator(_currentSchemaName, this))
            {
                //Classification
                _currentTableName = nameof(Classification);
                creatory.StartNewTable(_currentTableName);
                creatory.CreateBaseAdministrationEntity();

                //CustomFieldType
                _currentTableName = nameof(CustomFieldType);
                creatory.StartNewTable(_currentTableName);
                creatory.CreateBaseAdministrationEntity();

                //CustomField
                _currentTableName = nameof(CustomField);
                creatory.StartNewTable(_currentTableName);
                creatory.CreateBaseAdministrationEntity();
                creatory.AddMapping(BaseEntityCreator.MappingTypes.Classification);
                creatory.AddColumn(nameof(CustomField.CustomFieldTypeId));                
                creatory.AddForeignKey(_currentTableName, nameof(CustomFieldType), nameof(CustomField.CustomFieldTypeId));
                
                //CustomFieldValue
                _currentTableName = nameof(CustomFieldValue);
                creatory.StartNewTable(_currentTableName);
                creatory.CreateBaseEntity();
                creatory.AddColumn(nameof(CustomFieldValue.CustomFieldId));
                creatory.AddColumn(nameof(CustomFieldValue.Value), BaseEntityCreator.FieldTypes.AsString);
                creatory.AddForeignKey(_currentTableName, nameof(CustomField), nameof(CustomFieldValue.CustomFieldId));


                //Category 
                _currentTableName = nameof(Category);
                creatory.StartNewTable(_currentTableName);
                creatory.CreateBaseAdministrationEntity();
                creatory.AddMapping(BaseEntityCreator.MappingTypes.Classification);
                creatory.AddColumn(nameof(Category.ParentId));                
                creatory.AddForeignKey(_currentTableName, _currentTableName, nameof(BaseEntity.Id));
                                
                //CategoryCustomField
                _currentTableName = nameof(CategoryCustomField);
                creatory.StartNewTable(_currentTableName);
                creatory.CreateBaseEntity();
                creatory.AddMapping(BaseEntityCreator.MappingTypes.Category);

                //Notes
                _currentTableName = nameof(Note);
                creatory.StartNewTable(_currentTableName);
                creatory.CreateBaseAdministrationEntity();
                creatory.AddMapping(BaseEntityCreator.MappingTypes.Classification);

                

            }
        }

        /// <summary>
        /// Creates all catalog tables
        /// </summary>
        private void CreateCatalogTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Admin;
            using(var creatory = new BaseEntityCreator(_currentSchemaName, this))
            {
                //Product
                _currentTableName = nameof(Product);
                creatory.StartNewTable(_currentTableName);

                //Product Catalog
                _currentTableName = nameof(ProductCategory);
                creatory.StartNewTable(_currentTableName);
                creatory.CreateBaseEntity();
                creatory.AddMapping(BaseEntityCreator.MappingTypes.Product);
                creatory.AddMapping(BaseEntityCreator.MappingTypes.Category);
            }
            
        }

        private void CreateContactBaseTables()
        {

        }

        private void CreateProjectsTables()
        {

        }

        #endregion
    }
}

