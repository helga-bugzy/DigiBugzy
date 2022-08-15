

using DigiBugzy.Core.Domain.BusinessEntities;
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Core.Domain.Secures;
using DigiBugzy.Core.Domain.Settings;
using Microsoft.EntityFrameworkCore;

namespace DigiBugzy.Services
{
    public class DatabaseContext : DbContext
    {

        #region Administrations

        public DbSet<Classification> Classifications { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryCustomField> CategoryCustomFields { get; set; }

        public DbSet<CustomField> CustomFields { get; set; }

        public DbSet<CustomFieldType> CustomFieldTypes { get; set; }



        public DbSet<CustomFieldListOption> CustomFieldListOptions { get; set; }

        public DbSet<DigiAdmin> DigiAdmins { get; set; }

        public DbSet<Note> Notes { get; set; }

        #endregion

        #region Contact Base

        public DbSet<BusinessEntityType> BusinessEntityTypes { get; set; }

        #endregion

        #region Catalog

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductCustomField> ProductCustomFields { get; set; }

        #endregion

        #region Projects

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectSection> ProjectSections { get; set; }

        public DbSet<ProjectSectionPart> ProjectSectionParts { get; set; }

        #endregion

        #region Secure

        public DbSet<Bugzer> Bugzers { get; set; }


        #endregion

        #region Settings

        public DbSet<AdministrationSettings> AdministrationSettings { get; set; }

        public DbSet<ProductSettings> ProductSettings { get; set; }

        public DbSet<ProjectSettings> ProjectSettings { get; set; }

        public DbSet<GeneralSettings> GeneralSettings { get; set; }

        #endregion

        #region Ctor

        private readonly string _connectionString;


        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;

        }

        #endregion


        #region Overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
           // builder.Entity<CategoryCustomField>();


            base.OnModelCreating(builder);
        }

        #endregion


    }
}
