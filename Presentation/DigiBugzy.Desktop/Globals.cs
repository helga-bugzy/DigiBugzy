


global using FluentMigrator.Runner;
global using Microsoft.Extensions.DependencyInjection;
global using DigiBugzy.Core.Enumerations;

namespace DigiBugzy.Desktop
{
    public static class Globals
    {
        public static ConnectionEnvironment ConnectionEnvironment = ConnectionEnvironment.Development;

        public static string GetConnectionString(ConnectionEnvironment environment)
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
            return @"Data Source=ARDUIO1;Initial Catalog=DigiBugzyDev;Persist Security Info=True;User ID=sa;Password=Columbus01!";
        }

        public static string GetMasterConnectionString(ConnectionEnvironment environment)
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
            return @"Data Source=ARDUIO1;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Columbus01!";
        }
    }
}
