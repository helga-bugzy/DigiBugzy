﻿

namespace DigiBugzy.Data.Migrations
{

    /// <summary>
    /// https://dotnetcorecentral.com/blog/fluentmigrator/
    /// </summary>
    public static class Database
    {
        public static void EnsureDatabase(string connectionString, string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", name);
            using var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name",
                 parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
    }
}
