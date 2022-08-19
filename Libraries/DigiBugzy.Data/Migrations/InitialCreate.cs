global using DigiBugzy.Core.Domain.BusinessEntities;
using DigiBugzy.Core.Domain.Administration.Documents;
using DigiBugzy.Core.Domain.Finance.Assets;
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
            //Schemas
            CreateSchemas();

            //Admin-shared
            CreateAdministrationTables(); 
            CreateSettingsTables();
            
            CreateContactBaseTables();

            //Objects
            CreateFinanceTables();
            CreateCatalogTables();
            CreateProjectsTables();

            //Journals
            CreateStockJournal();

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

            //Documents
            _currentTableName = nameof(DocumentType);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            CreateData_DocumentTypes();

            _currentTableName = nameof(Document);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Classification);
            creatory.AddColumn(nameof(Document.DocumentTypeId), isNullable: false);
            creatory.AddForeignKey(_currentTableName, nameof(DocumentType), nameof(Document.DocumentTypeId), _currentSchemaName, _currentSchemaName);
            

        }

        private void CreateFinanceTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Finance;
            using var creatory = new BaseEntityCreator(_currentSchemaName, this);

            //Assets
            _currentTableName = nameof(AssetType);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            CreateData_AssetTypes();

            _currentTableName = nameof(Asset);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddColumn(nameof(Asset.AssetTypeId), isNullable: false);
            creatory.AddForeignKey(_currentTableName, nameof(AssetType), nameof(Asset.AssetTypeId), _currentSchemaName, _currentSchemaName);

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

        private void CreateContactBaseTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.ContactBase;
            using var creatory = new BaseEntityCreator(_currentSchemaName, this);
            //BusinessEntity
            _currentTableName = nameof(BusinessEntity);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();

            //BusinessEntityCategory
            _currentTableName = nameof(BusinessEntityCategory);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.BusinessEntity);
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Category, toSchemaName: DatabaseConstants.Schemas.Admin);
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
            creatory.AddColumn(nameof(Product.ParentId), isNullable: true);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                toTable: _currentTableName,
                fromFieldName: nameof(Product.ParentId),
                fromSchemaName: _currentSchemaName,
                toSchemaName: _currentSchemaName);

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
            creatory.AddColumn(nameof(ProductCustomField.Value), isNullable:true, fieldType: BaseEntityCreator.FieldTypes.AsString);

            
        }

        private void CreateProjectsTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Project;
            using var creatory = new BaseEntityCreator(schemaName: _currentSchemaName, migrator: this);

            //Project
            _currentTableName = nameof(Project);
            creatory.StartNewTable(tableName: _currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddColumn(
                fieldName: nameof(Project.CoverImage), 
                fieldType: BaseEntityCreator.FieldTypes.AsBinary, 
                isNullable: true);

            //Project Section
            _currentTableName = nameof(ProjectSection);
            creatory.StartNewTable(tableName: _currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddColumn(
                fieldName: nameof(ProjectSection.ProjectId), 
                isNullable: false, 
                fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddForeignKey(
                fromTable: _currentTableName, 
                toTable: nameof(Project), 
                fromFieldName: nameof(ProjectSection.ProjectId), 
                fromSchemaName: _currentSchemaName, 
                toSchemaName: _currentSchemaName);
            creatory.AddColumn(
                fieldName: nameof(ProjectSection.CoverImage), 
                fieldType: BaseEntityCreator.FieldTypes.AsBinary, 
                isNullable: true);

            //Project Section Part
            _currentTableName = nameof(ProjectSectionPart);
            creatory.StartNewTable(tableName: _currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddColumn(
                fieldName: nameof(ProjectSectionPart.ProjectSectionId), 
                isNullable: false, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddColumn(
                fieldName: nameof(ProjectSectionPart.CoverImage),
                fieldType: BaseEntityCreator.FieldTypes.AsBinary,
                isNullable: true);
            creatory.AddForeignKey(
                fromTable: _currentTableName, 
                toTable: nameof(ProjectSection), 
                fromFieldName: nameof(ProjectSectionPart.ProjectSectionId), 
                fromSchemaName: _currentSchemaName, 
                toSchemaName: _currentSchemaName);

            //Project Printing
            _currentTableName = nameof(ProjectPrinting);
            creatory.StartNewTable(tableName: _currentTableName);
            creatory.CreateBaseProjectSublementEntity();

            //Project Document
            _currentTableName = nameof(ProjectDocument);
            creatory.StartNewTable(tableName: _currentTableName);
            creatory.CreateBaseProjectSublementEntity();

            //Project Product
            _currentTableName = nameof(ProjectProduct);
            creatory.StartNewTable(tableName: _currentTableName);
            creatory.CreateBaseProjectSublementEntity();
            creatory.AddColumn(
                fieldName: nameof(ProjectProduct.ProductId), 
                isNullable: false, 
                fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddForeignKey(
                fromTable: _currentTableName, 
                toTable: nameof(Product), 
                fromFieldName: nameof(ProjectProduct.ProjectId), 
                fromSchemaName: _currentSchemaName,
                toSchemaName: DatabaseConstants.Schemas.Catalog);

            //Project Category
            _currentTableName = nameof(ProjectCategory);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Project);
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Category, toSchemaName: DatabaseConstants.Schemas.Admin);
        }

        private void CreateStockJournal()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Catalog;
            using var creatory = new BaseEntityCreator(schemaName: _currentSchemaName, migrator: this);
            _currentTableName = nameof(StockJournal);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddColumn(nameof(StockJournal.EntryDate), isNullable: false, fieldType: BaseEntityCreator.FieldTypes.AsDateTime);
            creatory.AddColumn(nameof(StockJournal.QuantityIn), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDouble);
            creatory.AddColumn(nameof(StockJournal.QuantityOut), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDouble);
            creatory.AddColumn(nameof(StockJournal.QuantityOnOrder), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDouble);
            creatory.AddColumn(nameof(StockJournal.TotalInStock), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDouble);
            creatory.AddColumn(nameof(StockJournal.QuantityReserved), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDouble);
            creatory.AddColumn(nameof(StockJournal.Price), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDouble);
            creatory.AddColumn(nameof(StockJournal.TotalValue), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDouble);

            //ProjectSectionPartId
            creatory.AddColumn(nameof(StockJournal.ProjectSectionPartId), isNullable: true);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                toTable: nameof(ProjectSectionPart),
                fromFieldName: nameof(StockJournal.ProjectSectionPartId),
                fromSchemaName: _currentSchemaName,
                toSchemaName: DatabaseConstants.Schemas.Project);

            //SupplierId
            creatory.AddColumn(nameof(StockJournal.SupplierId), isNullable: true);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                toTable: nameof(BusinessEntity),
                fromFieldName: nameof(StockJournal.SupplierId),
                fromSchemaName: _currentSchemaName,
                toSchemaName: DatabaseConstants.Schemas.ContactBase);

            //ProductId
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Product, toSchemaName: DatabaseConstants.Schemas.Catalog);
        }

        #endregion


        #region Create Data

        private void CreateData_AssetTypes()
        {
            Insert.IntoTable(nameof(AssetType))
                .InSchema(DatabaseConstants.Schemas.Finance)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Books",
                    Description = "Books"
                });


            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Woodworking Tools",
                    Description = "Woodworking Tools"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Robotic Tools",
                    Description = "Robotic Tools"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "General Tools",
                    Description = "General Tools"
                });


            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Tool Accessories",
                    Description = "Tool Accessories"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Tool Consumables",
                    Description = "Consumables"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Cartridges",
                    Description = "Cartidges"
                });

            Insert.IntoTable(nameof(CustomFieldType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Filamenten",
                    Description = "Filamenten"
                });
        }

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
           //Projects
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

            //Products
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

            //Business Entities
            Insert.IntoTable(nameof(Classification))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = nameof(BusinessEntity),
                    Description = nameof(BusinessEntity)

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

        private void CreateData_DocumentTypes()
        {
            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Invoice",
                    Description = "Invoice"
                });

            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Quotation",
                    Description = "Quotation"
                });

            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Specifications",
                    Description = "Specifications"
                });

            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "STL File",
                    Description = "STL File"
                });

            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "GCode File",
                    Description = "GCode File"
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

