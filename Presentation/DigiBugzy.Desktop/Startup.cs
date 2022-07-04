﻿

global using DigiBugzy.Data.Migrations;
global using DigiBugzy.Services.Administration.DigiAdmins;
global using DigiBugzy.Services.Administration.Categories;
global using DigiBugzy.Services.Administration.Classifications;
global using DigiBugzy.Services.Administration.Notes;
global using DigiBugzy.Services.Administration.CustomFields;
global using DigiBugzy.Services.Catalog.Products;

namespace DigiBugzy.Desktop
{
    public class Startup
    {
        #region Properties

        public static IServiceCollection? services { get; set; }

        public static IServiceProvider? ServiceProvider { get; set; }

        #endregion

        #region Public Methods

        public static void ConfigureService()
        {
            #region EF Core

            //Create database (https://dotnetcorecentral.com/blog/fluentmigrator/)
            Database.EnsureDatabase(Globals.GetMasterConnectionString(ConnectionEnvironment.Master), "DigiBugzyDev");

            //Entity framework (for migrations)
            ServiceProvider = CreateServices();


            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            //https://fluentmigrator.github.io/articles/quickstart.html?tabs=runner-in-process
            using (var scope = ServiceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            #endregion

            #region Dependency Injection

            services = new ServiceCollection();

            RegisterServices();

            RegisterForms();


            ServiceProvider = services.BuildServiceProvider();

            #endregion
        }

        #endregion

        #region Dependency Injection

        /// <summary>
        /// Configure the dependency injection services
        /// https://fluentmigrator.github.io/articles/quickstart.html?tabs=runner-in-process
        /// </summary>
        private static IServiceProvider CreateServices()
        {
            var provider = new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(Globals.GetConnectionString(Globals.ConnectionEnvironment))
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(InitialCreate).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);

            return provider;
        }


        private static void RegisterForms()
        {
            if (services != null)
            {
                services.AddScoped<LoginForm>();
               

            }
        }

        private static void RegisterServices()
        {
            if (services != null)
            {
                //Administration
                services.AddTransient<IDigiAdminService, DigiAdminService>();
                services.AddTransient<ICategoryService, CategoryService>();
                services.AddTransient<IClassificationService, ClassificationService>();
                services.AddTransient<ICustomFieldService, CustomFieldService>();
                services.AddTransient<ICustomFieldTypeService, CustomFieldTypeService>();
                services.AddTransient<INoteService, NoteService>();

                //Products
                services.AddTransient<IProductService, ProductService>();
                services.AddTransient<IProductCustomFieldService, ProductCustomFieldService>();
                services.AddTransient<IProductCategoryService, ProductCategoryService>();

                //Projects
                services.AddTransient<IProjectService, ProjectService>();
            }
        }


        #endregion

        #region Migrations

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
        #endregion

        #region Installation Validations

        /// <summary>
        /// Validates if any administrations exists
        /// If false, the installation wizard must run
        /// </summary>
        /// <returns></returns>
        public static bool HasAdministrations()
        {

            //using (var service = GetService<IAdministrationService>())
            //{
            //    return service != null && service.HasItems();
            //}

            return false;
        }

        #endregion

        #region Services

        /// <summary>
        /// Gets a service class from the dependency injection provider
        /// /// usage: (var service = Startup.GetForm&lt;InstallationWizard&gt;()){...}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? GetService<T>() where T : class
        {
            return (T?)ServiceProvider?.GetRequiredService(typeof(T));
        }

        /// <summary>
        /// Gets a windows form fron the dependency intjection provider
        /// usage: Startup.GetForm&lt;InstallationWizard&gt;();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? GetForm<T>() where T : Form
        {
            return (T?)ServiceProvider?.GetRequiredService(typeof(T));
        }

        #endregion
    }
}
