global using DigiBugzy.Core.Domain.Administration.Documents;
using DigiBugzy.Core.Domain.Finance.Assets;

namespace DigiBugzy.Data.Migrations
{
    [Migration(002)]
    public class DocumentsPhase1: Migration
    {
        #region Properties

        private string _currentTableName = string.Empty;

        private string _currentSchemaName = string.Empty;


        #endregion

        public override void Up()
        {
            DeleteTables();
            CreateAdminTables();

            CreateProjectDocumentTables();
            CreateProductDocumentTables();
            CreateAssetDocumentTables();
            CreateBusinessEntityDocumentTables();

        }

        public override void Down()
        {
            
        }

        #region Delete Tables

        private void DeleteTables()
        {
            Delete.Table("Document").InSchema(DatabaseConstants.Schemas.Admin);
            Delete.Table(nameof(DocumentType)).InSchema(DatabaseConstants.Schemas.Admin);
        }

        #endregion

        #region Create Tables

        private void CreateAdminTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Admin;

            using var creatory = new BaseEntityCreator(_currentSchemaName, this);

            //DocumentFileType
            _currentTableName = nameof(DocumentFileType);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddColumn(fieldName: nameof(DocumentFileType.Extension), isNullable: false, fieldType: BaseEntityCreator.FieldTypes.AsString);
            CreateData_DocumentFileTypes();

            //DocumentType
            _currentTableName = nameof(DocumentType);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();
            creatory.AddColumn(nameof(DocumentType.DefaultDocumentFileTypeId), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Classification);
            creatory.AddForeignKey(
                fromTable: _currentTableName, 
                fromFieldName:nameof(DocumentType.DefaultDocumentFileTypeId),
                fromSchemaName: _currentSchemaName,
                toTable: nameof(DocumentType), 
                toSchemaName: _currentSchemaName);
            CreateData_DocumentTypes();
            
        }

        private void CreateProductDocumentTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Catalog;
            _currentTableName = nameof(ProductDocument);

            using var creatory = new BaseEntityCreator(_currentSchemaName, this);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseDocumentEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Product);
            creatory.AddColumn(nameof(ProductDocument.IsSpecifications), BaseEntityCreator.FieldTypes.AsBoolean, false);
            creatory.AddColumn(nameof(ProductDocument.IsInstructions), BaseEntityCreator.FieldTypes.AsBoolean, false);
            creatory.AddColumn(nameof(ProductDocument.IsWarranty), BaseEntityCreator.FieldTypes.AsBoolean, false);
        }

        private void CreateProjectDocumentTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Project;
            _currentTableName = nameof(ProjectDocument);

            using var creatory = new BaseEntityCreator(_currentSchemaName, this);
            creatory.StartNewTable(_currentTableName);
            creatory.AddColumn(nameof(ProjectDocument.Is3DPrintingDocument), BaseEntityCreator.FieldTypes.AsBoolean, false);
            creatory.AddColumn(nameof(ProjectDocument.IsSpecifications), BaseEntityCreator.FieldTypes.AsBoolean, false);
            creatory.AddColumn(nameof(ProjectDocument.IsPlans), BaseEntityCreator.FieldTypes.AsBoolean, false);
            creatory.AddColumn(nameof(ProjectDocument.IsInstructions), BaseEntityCreator.FieldTypes.AsBoolean, false);

        }

        private void CreateAssetDocumentTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Finance;
            _currentTableName = nameof(AssetDocument);

            using var creatory = new BaseEntityCreator(_currentSchemaName, this);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseDocumentEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.Asset);
            creatory.AddColumn(nameof(AssetDocument.IsInstructions), BaseEntityCreator.FieldTypes.AsBoolean, false);
            creatory.AddColumn(nameof(AssetDocument.IsSpecifications), BaseEntityCreator.FieldTypes.AsBoolean, false);
            creatory.AddColumn(nameof(AssetDocument.IsWarranty), BaseEntityCreator.FieldTypes.AsBoolean, false);
        }

        private void CreateBusinessEntityDocumentTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.ContactBase;
            _currentTableName = nameof(BusinessEntityDocument);

            using var creatory = new BaseEntityCreator(_currentSchemaName, this);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseDocumentEntity();
            creatory.AddMapping(BaseEntityCreator.MappingTypes.BusinessEntity);
        }

        #endregion

        #region Create Data

        private void CreateData_Classifications()
        {
            //Finance
            Insert.IntoTable(nameof(Classification))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = nameof(DatabaseConstants.Schemas.Finance),
                    Description = nameof(DatabaseConstants.Schemas.Finance)
                }) ;
        }

        private void CreateData_DocumentTypes()
        {
            //Image
            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Image",
                    Description = "Image",
                    ClassificationId = 1
                });

            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Image",
                    Description = "Image",
                    ClassificationId = 2
                });

            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Image",
                    Description = "Image",
                    ClassificationId = 3
                });



            //Schemas
            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Schematic Drawing",
                    Description = "Schematic Drawing",
                    ClassificationId = 1
                });

            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Schematic Drawing",
                    Description = "Schematic Drawing",
                    ClassificationId = 2
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
                    Description = "Specifications",
                    ClassificationId = 1
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
                    Description = "Specifications",
                    ClassificationId = 2
                });

            //Projects
            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "GCode File",
                    Description = "GCode File",
                    ClassificationId = 1
                });


            Insert.IntoTable(nameof(DocumentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Stl File",
                    Description = "String",
                    ClassificationId = 1
                });

           
        }

        private void CreateData_DocumentFileTypes()
        {
            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "PDF Reader",
                    Description = "PDF",
                    Extension = "pdf"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Word Document",
                    Description = "Microsoft Word Document",
                    Extension = "docx"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Excel Spreadsheet",
                    Description = "Excel Spreadsheet",
                    Extension = "xlsx"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "3D Stl Drawing",
                    Description = "3D Stl Drawing",
                    Extension = "stl"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "3D GCode File",
                    Description = "GCode file for 3D printer",
                    Extension = "gcode"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Image - Jpg",
                    Description = "Image - Jpg",
                    Extension = "jpg"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Image - Png",
                    Description = "Image - Png",
                    Extension = "png"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Image - Gif",
                    Description = "Image - Gif",
                    Extension = "gif"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Xml",
                    Description = "Xml",
                    Extension = "xml"
                });

            Insert.IntoTable(nameof(DocumentFileType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "JSon",
                    Description = "JSON",
                    Extension = "json"
                });


        }

        #endregion
    }
}
