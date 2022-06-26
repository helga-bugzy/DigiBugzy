﻿global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;


global using FluentMigrator.Runner;
global using Microsoft.Extensions.DependencyInjection;

global using DigiBugzy.Desktop.MainContainers.Forms;

global using DigiBugzy.Application.Enumerations;





namespace DigiBugzy.Desktop
{
    public static class Globals
    {
        public static ConnectionEnvironment ConnectionEnvironment = ConnectionEnvironment.Development;
       
        public static string GetConnectionString(ConnectionEnvironment environment)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
        }

    }
}