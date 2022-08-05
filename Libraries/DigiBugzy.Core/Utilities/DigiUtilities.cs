
using System.Drawing;
using System.Drawing.Imaging;

namespace DigiBugzy.Core.Utilities
{
    /// <summary>
    /// Static class with small helper methods that are used on more than one place
    /// </summary>
    public static class DigiUtilities
    {

        #region Strings

        public static string CreateLevelName(string name, int level)
        {
            if (level == 0) return name;

            var stringName = "";
            for (var i = 0; i < level; i++)
            {
                stringName += "-";
            }
            return $@"{stringName} {name}";
        }

        #endregion
    }
}
