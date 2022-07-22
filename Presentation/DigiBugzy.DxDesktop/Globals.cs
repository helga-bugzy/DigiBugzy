using DigiBugzy.Core.Enumerations;

namespace DigiBugzy.DxDesktop
{
    public class Globals
    {
        public static ConnectionEnvironment ConnectionEnvironment = ConnectionEnvironment.Development;

        public static string GetConnectionString()
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
            //return @"Data Source=ARDUIO1;Initial Catalog=DigiBugzyDev;Persist Security Info=True;User ID=sa;Password=Columbus01!";
            return @"Data Source=LCVPC5900\SQLEXPRESS;Initial Catalog=DigiBugzyDev;Persist Security Info= False; Integrated Security=true";
        }

        public static string GetMasterConnectionString()
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(ConnectionEnvironment), environment)].ConnectionString;
            return @"Data Source=LCVPC5900\SQLEXPRESS;Initial Catalog=master;Persist Security Info=False;Integrated Security=true";
        }

        /// <summary>
        /// Selected digiAdmin
        /// </summary>
        public static DigiAdmin DigiAdministration { get; set; } = new();
    }
}
