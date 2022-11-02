global using FluentMigrator.Runner;
global using Microsoft.Extensions.DependencyInjection;
global using DigiBugzy.Core.Enumerations;
global using DigiBugzy.Core.Extensions;
using System.Linq;
using DigiBugzy.Core.Domain.Settings;
using DigiBugzy.Services.Settings;

namespace DigiBugzy.Desktop
{
    public static class Globals
    {

        public static ConnectionEnvironment ConnectionEnvironment = ConnectionEnvironment.Development;
        
        private const string DatabaseName_Dev = "DigiBugzyDev";
        private const string DatabaseName_Prod = "Schuring1digibugzy";

        public static string GetDatabaseName =>
            ConnectionEnvironment == ConnectionEnvironment.Development
                ? DatabaseName_Dev
                : DatabaseName_Prod;

        public static string GetConnectionString()
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
            // return @"Data Source=ARDUIO1;Initial Catalog=DigiBugzyDev;Persist Security Info=True;User ID=sa;Password=Columbus01!";

            return GetDatabaseName == DatabaseName_Dev ?
                @$"Data Source=LCVPC5900\SQLEXPRESS;Initial Catalog={GetDatabaseName};Persist Security Info=False;Trusted_Connection=True;" :
                $"Data Source=185.41.126.25,9146;Initial Catalog={GetDatabaseName};Persist Security Info=True;User ID=...;Password=...";


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

            
            private static AdministrationSettings? _administrationSettings;

            public static AdministrationSettings? AdministrationSettings
            {
                get

                {
                    if (_administrationSettings is { Id: <= 0 }) Refresh();
                    return _administrationSettings;
                }
                set => _administrationSettings = value;
            }

            private static GeneralSettings?_generalSettings;

            public static GeneralSettings? GeneralSettings
            {
                get
                {
                    if (_generalSettings is { Id: <= 0 }) Refresh();
                    return _generalSettings;
                }
                set => _generalSettings = value;
            }

            private static ProductSettings? _productSettings;
            public static ProductSettings? ProductSettings
            {
                get
                {
                    if (_productSettings is { Id: <= 0 }) Refresh();
                    return _productSettings;
                }
                set => _productSettings = value;
            }


            private static ProjectSettings? _projectSettings;
            public static ProjectSettings? ProjectSettings
            {
                get
                {
                    if (_projectSettings is { Id: <= 0 }) Refresh();
                    return _projectSettings;
                }
                set => _projectSettings = value;
            }

            

            #endregion

            #region Methods

            public static void Refresh()
            {
                Refresh_AdministrationSettings();
                Refresh_GeneralSettings();
                
                Refresh_ProjectSettings();
                Refresh_ProductSettings();
            }

            public static void Refresh_AdministrationSettings()
            {
                using var service = new AdministrationSettingsService(GetConnectionString());
                AdministrationSettings = service.Get(DigiAdministration.Id).FirstOrDefault()!;
            }

            public static void Refresh_GeneralSettings()
            {
                using var service = new GeneralSettingsService(GetConnectionString());
                GeneralSettings = service.Get(DigiAdministration.Id).FirstOrDefault()!;
            }

            public static void Refresh_ProductSettings()
            {
                using var service = new ProductSettingsService(GetConnectionString());
                ProductSettings = service.Get(DigiAdministration.Id).FirstOrDefault()!;
            }


            public static void Refresh_ProjectSettings()
            {
                using var service = new ProjectSettingsService(GetConnectionString());
                ProjectSettings = service.Get(DigiAdministration.Id).FirstOrDefault()!;
            }

            #endregion

        }
    }
}
