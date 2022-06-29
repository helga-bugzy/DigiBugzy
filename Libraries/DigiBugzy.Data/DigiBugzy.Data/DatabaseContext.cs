
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Domain
{
    public class DatabaseContext : DbContext
    {

        #region Administrations

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryCustomField> CategoryCustomFields { get; set; }

        public DbSet<Classification> Classifications { get; set; }

        public DbSet<CustomField> CustomFields { get; set; }

        public DbSet<CustomFieldType> CustomFieldTypes { get; set; }

        public DbSet<CustomFieldValue> CustomFieldValues { get; set; }

        public DbSet<DigiAdmin> DigiAdmins { get; set; }

        public DbSet<Note> Notes { get; set; }

        #endregion

        #region Contact Base

        public DbSet<BusinessEntityType> BusinessEntityTypes { get; set; }

        #endregion

        #region Catalog

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        #endregion

        #region Projects

        public DbSet<Project> Projects { get; set; }

        #endregion

        #region Secure

        public DbSet<Bugzer> Bugzers { get; set; }


        #endregion

        private string _connectionString;


        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        
        
    }
}
