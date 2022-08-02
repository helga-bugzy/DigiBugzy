global using FluentMigrator.Runner;
global using Microsoft.Extensions.DependencyInjection;
global using DigiBugzy.Core.Enumerations;
using System.Linq;
using DigiBugzy.Core.Domain.Settings;
using DigiBugzy.Services.Settings;

namespace DigiBugzy.Desktop
{
    public static class Globals
    {
        public static ConnectionEnvironment ConnectionEnvironment = ConnectionEnvironment.Development;
        private const string DatabaseName_Dev = "DigiBugzyDev";
        private const string DatabaseName_Prod = "DigiBugzyProd";

        public static string GetDatabaseName =>
            ConnectionEnvironment == ConnectionEnvironment.Development
                ? DatabaseName_Dev
                : DatabaseName_Prod;

        public static string GetConnectionString()
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
           // return @"Data Source=ARDUIO1;Initial Catalog=DigiBugzyDev;Persist Security Info=True;User ID=sa;Password=Columbus01!";
           
           return @$"Data Source=LCVPC5900\SQLEXPRESS;Initial Catalog={GetDatabaseName};Persist Security Info=False;Trusted_Connection=True;";
           
        }

        public static string GetMasterConnectionString()
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
            //return @"Data Source=ARDUIO1;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Columbus01!";
            return @"Data Source=LCVPC5900\SQLEXPRESS;Initial Catalog=master;Persist Security Info=False;Trusted_Connection=True;";
        }

        /// <summary>
        /// Selected digiAdmin
        /// </summary>
        public static DigiAdmin DigiAdministration { get; set; } = new();

        public static class Settings
        {
            #region Properties

            public static ProductSettings? ProductSettings { get; set; } = new();

            public static AdministrationSettings? AdministrationSettings { get; set; } = new();

            public static ProjectSettings? ProjectSettings { get; set; } = new();

            public static GeneralSettings? GeneralSettings { get; set; } = new();

            #endregion

            #region Methods

            public static void Refresh()
            {
                Refresh_AdministrationSettings();
                Refresh_GeneralSettings();
                Refresh_ProductSettings();
                Refresh_ProjectSettings();
            }

            public static void Refresh_AdministrationSettings()
            {
                using var service = new AdministrationSettingsService(GetConnectionString());
                AdministrationSettings = service.Get(DigiAdministration.Id).FirstOrDefault();
            }

            public static void Refresh_GeneralSettings()
            {
                using var service = new GeneralSettingsService(GetConnectionString());
                GeneralSettings = service.Get(DigiAdministration.Id).FirstOrDefault();
            }

            public static void Refresh_ProductSettings()
            {
                using var service = new ProductSettingsService(GetConnectionString());
                ProductSettings = service.Get(DigiAdministration.Id).FirstOrDefault();
            }


            public static void Refresh_ProjectSettings()
            {
                using var service = new ProjectSettingsService(GetConnectionString());
                ProjectSettings = service.Get(DigiAdministration.Id).FirstOrDefault();
            }

            #endregion



        }

        

        
    }
}
