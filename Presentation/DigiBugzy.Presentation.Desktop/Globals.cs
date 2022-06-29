global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Reflection;

global using MediatR;
global using AutoMapper;


global using FluentMigrator.Runner;
global using Microsoft.Extensions.DependencyInjection;

global using DigiBugzy.Presentation.Desktop;
global using DigiBugzy.Presentation.Desktop.MainContainers.Forms;

global using DigiBugzy.Data.Enumerations;
global using DigiBugzy.Data.Migrations;

global using DigiBugzy.Data.Common.xBaseObjects.FilterObjects;

global using DigiBugzy.Data.CommandHandlers.Administrations.DigiAdmins.Models;
global using DigiBugzy.Data.CommandHandlers.Administrations.DigiAdmins.Queries;
global using DigiBugzy.Data.CommandHandlers.Administrations.DigiAdmins.Commands;

namespace DigiBugzy.Presentation.Desktop
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
