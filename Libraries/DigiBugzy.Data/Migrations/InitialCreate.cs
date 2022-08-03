global using DigiBugzy.Core.Domain.BusinessEntities;
using DigiBugzy.Core.Domain.Settings;
using DigiBugzy.Core.Helpers;

namespace DigiBugzy.Data.Migrations
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
            CreateSettingsTables();

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

            using var creatory = new BaseEntityCreator(_currentSchemaName, this);

            _currentTableName = nameof(DigiAdmin);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseDigiAdminEntity();
            CreateData_DigiAdmin();

            //Classification
            _currentTableName = nameof(Classification);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            CreateData_Classifications();

            //CustomFieldType
            _currentTableName = nameof(CustomFieldType);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            CreateData_CustomFieldTypes();

            //CustomField
            _currentTableName = nameof(CustomField);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Classification);
            creatory.AddColumn(nameof(CustomField.CustomFieldTypeId));                
            creatory.AddForeignKey(_currentTableName, nameof(CustomFieldType), nameof(CustomField.CustomFieldTypeId));
                
            //CustomFieldValue
            _currentTableName = nameof(CustomFieldListOption);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseEntity();
            creatory.AddColumn(nameof(CustomFieldListOption.CustomFieldId));
            creatory.AddColumn(nameof(CustomFieldListOption.Value), BaseEntityCreator.FieldTypes.AsString);
            creatory.AddForeignKey(_currentTableName, nameof(CustomField), nameof(CustomFieldListOption.CustomFieldId));


            //Category 
            _currentTableName = nameof(Category);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Classification);
            creatory.AddColumn(nameof(Category.ParentId), isNullable: true);                
            creatory.AddForeignKey( 
                fromTable: _currentTableName, 
                toTable: _currentTableName, 
                fromFieldName: nameof(Category.ParentId),  
                fromSchemaName: _currentSchemaName,
                toSchemaName: _currentSchemaName);
                                
            //CategoryCustomField
            _currentTableName = nameof(CategoryCustomField);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Category);
            creatory.AddMapping(BaseEntityCreator.MappingTypes.CustomField);

            //Notes
            _currentTableName = nameof(Note);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Classification);

            
           
            
        }

        public void CreateSettingsTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Settings;
            using var creatory = new BaseEntityCreator(_currentSchemaName, this);

            //General Settings
            _currentTableName = nameof(GeneralSettings);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseSettingsEntity();
            
            //Administration Settings
            _currentTableName = nameof(AdministrationSettings);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseSettingsEntity();


            //Project Settings
            _currentTableName = nameof(ProjectSettings);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseSettingsEntity();
            creatory.AddColumn(nameof(ProjectSettings.AutomateCategoryMappings), fieldType: BaseEntityCreator.FieldTypes.AsBoolean);
            creatory.AddColumn(nameof(ProjectSettings.AutomateFieldMappings), fieldType: BaseEntityCreator.FieldTypes.AsBoolean);

            //Product Settings
            _currentTableName = nameof(ProductSettings);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseSettingsEntity();
            creatory.AddColumn(nameof(ProductSettings.AutomateCategoryMappings), fieldType: BaseEntityCreator.FieldTypes.AsBoolean);
            creatory.AddColumn(nameof(ProductSettings.AutomateFieldMappings), fieldType: BaseEntityCreator.FieldTypes.AsBoolean);

            //Generate data
            CreateSettingsData();

        }

        /// <summary>
        /// Creates all catalog tables
        /// </summary>
        private void CreateCatalogTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Catalog;
            using var creatory = new BaseEntityCreator(_currentSchemaName, this);

            //Product
            _currentTableName = nameof(Product);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddColumn(fieldName: nameof(Product.ProductImage), fieldType: BaseEntityCreator.FieldTypes.AsBinary, isNullable: true);

            //ProductCategory
            _currentTableName = nameof(ProductCategory);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Product);
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Category, toSchemaName: DatabaseConstants.Schemas.Admin);
            

            // ProductCustomFieldValues
            _currentTableName = nameof(ProductCustomField);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Product, toSchemaName: DatabaseConstants.Schemas.Catalog);
            creatory.AddMapping(BaseEntityCreator.MappingTypes.CustomField, toSchemaName: DatabaseConstants.Schemas.Admin);
            creatory.AddColumn(nameof(ProductCustomField.Value), isNullable:true);
        }

        private void CreateContactBaseTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.ContactBase;
            using var creatory = new BaseEntityCreator(_currentSchemaName, this);
            //BusinessEntityType
            _currentTableName = nameof(BusinessEntityType);
            creatory.StartNewTable(_currentTableName);
           creatory.CreateBaseEntity();
        }

        private void CreateProjectsTables()
        {

        }

        #endregion


        #region Create Data

        private void CreateData_DigiAdmin()
        {
            Insert.IntoTable(nameof(DigiAdmin))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {                    
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Sample Administration",
                    Description = "Sample Administration"
                });


        }

        private void CreateData_Classifications()
        {
           
            Insert.IntoTable(nameof(Classification))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = nameof(Project),
                    Description = nameof(Project)
                });

            Insert.IntoTable(nameof(Classification))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = nameof(Product),
                    Description = nameof(Product)

                });

        }

        private void CreateData_CustomFieldTypes()
        {
            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Integer",
                    Description = "Integer"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Decimal",
                    Description = "Decimal"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Currency",
                    Description = "Currency"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "String",
                    Description = "String"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Memo",
                    Description = "Memo"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Boolean",
                    Description = "Boolean"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "List",
                    Description = "List"
                });
        }

        private void CreateData_BusinessEntityTypes()
        {
            Insert.IntoTable(nameof(BusinessEntityType))
                .InSchema(DatabaseConstants.Schemas.ContactBase)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Manufacturer",
                    Description = "Manufacturer"
                });

            Insert.IntoTable(nameof(BusinessEntityType))
                .InSchema(DatabaseConstants.Schemas.ContactBase)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Supplier",
                    Description = "Supplier"
                });

            Insert.IntoTable(nameof(BusinessEntityType))
                .InSchema(DatabaseConstants.Schemas.ContactBase)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Customer",
                    Description = "Customer"
                });

            Insert.IntoTable(nameof(BusinessEntityType))
                .InSchema(DatabaseConstants.Schemas.ContactBase)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Financial Institution",
                    Description = "Financial Institution"
                });

            Insert.IntoTable(nameof(BusinessEntityType))
                .InSchema(DatabaseConstants.Schemas.ContactBase)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Other",
                    Description = "Other"
                });
        }

        private void CreateSettingsData()
        {
            Insert.IntoTable(nameof(ProductSettings))
                .InSchema(DatabaseConstants.Schemas.Settings)
                .Row(new
                {
                    DigiAdminId = 1,
                    ApplyAutomationDown = true,
                    ApplyAutomationUp = true,
                    AllowSettingOverrides = true,
                    AutomateCategoryMappings = true,
                    AutomateFieldMappings = true,
                    ImageHeight = 250,
                    ImageWidth = 250,
                    ThumbWidth = 30,
                    ThumbHeight = 30
                });

                Insert.IntoTable(nameof(ProjectSettings))
                .InSchema(DatabaseConstants.Schemas.Settings)
                .Row(new
                {
                    DigiAdminId = 1,
                    ApplyAutomationDown = true,
                    ApplyAutomationUp = true,
                    AllowSettingOverrides = true,
                    AutomateCategoryMappings = true,
                    AutomateFieldMappings = true,
                    ImageHeight = 250,
                    ImageWidth = 250,
                    ThumbWidth = 30,
                    ThumbHeight = 30

                });

                Insert.IntoTable(nameof(GeneralSettings))
                    .InSchema(DatabaseConstants.Schemas.Settings)
                    .Row(new
                    {
                        DigiAdminId = 1,
                        ApplyAutomationDown = true,
                        ApplyAutomationUp = true,
                        AllowSettingOverrides = true,
                        ImageHeight = 250,
                        ImageWidth = 250,
                        ThumbWidth = 30,
                        ThumbHeight = 30
                    });

                Insert.IntoTable(nameof(AdministrationSettings))
                    .InSchema(DatabaseConstants.Schemas.Settings)
                    .Row(new
                    {
                        DigiAdminId = 1,
                        ApplyAutomationDown = true,
                        ApplyAutomationUp = true,
                        AllowSettingOverrides = true,
                        ImageHeight = 250,
                        ImageWidth = 250,
                        ThumbWidth = 30,
                        ThumbHeight = 30
                    });


        }

        #endregion
    }
}

