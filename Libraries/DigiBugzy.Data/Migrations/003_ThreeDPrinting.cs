using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBugzy.Core.Domain.Administration.ThreeDPrinting;

namespace DigiBugzy.Data.Migrations
{
    [Migration(003)]

    public class ThreeDPrinting: Migration
    {
        #region Properties

        private string _currentTableName = string.Empty;

        private string _currentSchemaName = string.Empty;


        #endregion

        #region Overrides

        /// <inheritdoc />
        public override void Up()
        {
            //Delete current project printing table
            DeleteTables();

            //Create printing admin tables
            CreateAdminTables();
            CreatePrinters();
            CreateFilamentColors();
            CreateFilamentTypes();
            CreateResolutions();

            //Create Printing table
            CreatePrintingTable();

        }

        /// <inheritdoc />
        public override void Down()
        {
            //throw new NotImplementedException();
        }

        #endregion

        #region Delete Tables

        private void DeleteTables()
        {
            Delete.Table(nameof(ProjectPrinting)).InSchema(DatabaseConstants.Schemas.Project);
            
        }

        #endregion

        #region Create Tables

        private void CreateAdminTables()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Admin;
            using var creatory = new BaseEntityCreator(_currentSchemaName, this);

            _currentTableName = nameof(ThreeDFilamentColor);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();

            _currentTableName = nameof(ThreeDFilamentType);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();

            _currentTableName = nameof(ThreeDPrinter);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();

            _currentTableName = nameof(ThreeDResolution);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseAdministrationEntity();

        }

        private void CreatePrintingTable()
        {
            _currentSchemaName = DatabaseConstants.Schemas.Project;
            using var creatory = new BaseEntityCreator(_currentSchemaName, this);
            _currentTableName = nameof(ProjectPrinting);
            creatory.StartNewTable(_currentTableName);
            creatory.CreateBaseProjectSublementEntity();

            creatory.AddColumn(nameof(ProjectPrinting.EstimatedPrintTime), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsString);
            creatory.AddColumn(nameof(ProjectPrinting.ActualPrintTime), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsString);

            creatory.AddColumn(nameof(ProjectPrinting.Infil), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDecimal);
            creatory.AddColumn(nameof(ProjectPrinting.WallThickness), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDecimal);
            creatory.AddColumn(nameof(ProjectPrinting.FilamentUsedGram), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDecimal);
            creatory.AddColumn(nameof(ProjectPrinting.FilamentUsedMeter), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsDecimal);

            creatory.AddColumn(nameof(ProjectPrinting.RequiredQuantity), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddColumn(nameof(ProjectPrinting.ActualQuantity), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            

            creatory.AddColumn(nameof(ProjectPrinting.StlFileName), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsString);
            creatory.AddColumn(nameof(ProjectPrinting.IsGCodeMade), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsBoolean);

            creatory.AddColumn(nameof(ProjectPrinting.GCodeFile), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsBinary);
            creatory.AddColumn(nameof(ProjectPrinting.StlFile), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsBinary);
            creatory.AddColumn(nameof(ProjectPrinting.CadFile), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsBinary);
            creatory.AddColumn(nameof(ProjectPrinting.Picture), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsBinary);

            creatory.AddColumn(nameof(ProjectPrinting.PrinterId), isNullable: false, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                fromFieldName: nameof(ProjectPrinting.PrinterId),
                fromSchemaName: _currentSchemaName,
                toTable: nameof(ThreeDPrinter),
                toSchemaName: DatabaseConstants.Schemas.Admin);

            creatory.AddColumn(nameof(ProjectPrinting.ResolutionId), isNullable: false, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                fromFieldName: nameof(ProjectPrinting.ResolutionId),
                fromSchemaName: _currentSchemaName,
                toTable: nameof(ThreeDResolution),
                toSchemaName: DatabaseConstants.Schemas.Admin);

            creatory.AddColumn(nameof(ProjectPrinting.RequiredFilamentTypeId), isNullable: false, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                fromFieldName: nameof(ProjectPrinting.RequiredFilamentTypeId),
                fromSchemaName: _currentSchemaName,
                toTable: nameof(ThreeDFilamentType),
                toSchemaName: DatabaseConstants.Schemas.Admin);

            creatory.AddColumn(nameof(ProjectPrinting.RequiredFilamentColorId), isNullable: false, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                fromFieldName: nameof(ProjectPrinting.RequiredFilamentColorId),
                fromSchemaName: _currentSchemaName,
                toTable: nameof(ThreeDFilamentColor),
                toSchemaName: DatabaseConstants.Schemas.Admin);

            creatory.AddColumn(nameof(ProjectPrinting.ActualFilamentTypeId), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                fromFieldName: nameof(ProjectPrinting.ActualFilamentTypeId),
                fromSchemaName: _currentSchemaName,
                toTable: nameof(ThreeDFilamentType),
                toSchemaName: DatabaseConstants.Schemas.Admin);

            creatory.AddColumn(nameof(ProjectPrinting.ActualFilamentColorId), isNullable: true, fieldType: BaseEntityCreator.FieldTypes.AsInt32);
            creatory.AddForeignKey(
                fromTable: _currentTableName,
                fromFieldName: nameof(ProjectPrinting.ActualFilamentColorId),
                fromSchemaName: _currentSchemaName,
                toTable: nameof(ThreeDFilamentColor),
                toSchemaName: DatabaseConstants.Schemas.Admin);

        }

        #endregion

        #region Create Data

        private void CreatePrinters()
        {
            Insert.IntoTable(nameof(ThreeDPrinter))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Ender 3 v2 (a)",
                    Description = "Ender 3 v2 (a)"
                });
        }

        private void CreateFilamentColors()
        {
            Insert.IntoTable(nameof(ThreeDFilamentColor))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "White",
                    Description = "White"
                });

            Insert.IntoTable(nameof(ThreeDFilamentColor))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Black",
                    Description = "Black"
                });

            Insert.IntoTable(nameof(ThreeDFilamentColor))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Wood",
                    Description = "Wood"
                });

            Insert.IntoTable(nameof(ThreeDFilamentColor))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Skin",
                    Description = "Skin"
                });

            Insert.IntoTable(nameof(ThreeDFilamentColor))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Blue",
                    Description = "Blue"
                });
        }

        private void CreateFilamentTypes()
        {
            Insert.IntoTable(nameof(ThreeDFilamentType))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "PLA",
                    Description = "PLA"
                });

        }

        private void CreateResolutions()
        {
            Insert.IntoTable(nameof(ThreeDResolution))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Standard",
                    Description = "Standard"
                });

            Insert.IntoTable(nameof(ThreeDResolution))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "High",
                    Description = "High"
                });

            Insert.IntoTable(nameof(ThreeDResolution))
                .InSchema(DatabaseConstants.Schemas.Admin)
                .Row(new
                {
                    DigiAdminId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    Name = "Low",
                    Description = "Low"
                });
        }

        #endregion

    }
}
