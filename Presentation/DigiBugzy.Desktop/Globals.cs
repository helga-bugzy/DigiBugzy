﻿


global using FluentMigrator.Runner;
global using Microsoft.Extensions.DependencyInjection;
global using DigiBugzy.Core.Enumerations;

namespace DigiBugzy.Desktop
{
    public static class Globals
    {
        public static ConnectionEnvironment ConnectionEnvironment = ConnectionEnvironment.Development;

        public static string GetConnectionString()
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
           // return @"Data Source=ARDUIO1;Initial Catalog=DigiBugzyDev;Persist Security Info=True;User ID=sa;Password=Columbus01!";
            return @"Data Source=LCVPC5900\SQLEXPRESS;Initial Catalog=DigiBugzyDev;Persist Security Info=True;";
        }

        public static string GetMasterConnectionString()
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
            //return @"Data Source=ARDUIO1;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Columbus01!";
            return @"Data Source=LCVPC5900\SQLEXPRESS;Initial Catalog=DigiBugzyDev;Persist Security Info=True;Trusted_Connection=True;";
        }

        /// <summary>
        /// Selected digiAdmin
        /// </summary>
        public static DigiAdmin DigiAdministration { get; set; } = new();
    }
}
