using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DBActions
    {
        static string connString;

        public static string GetConnectionString(string connStrNameInCnfig)
        {
            if (connString != null)
            {
                return connString;
            }
            string connStr = ConfigurationManager.ConnectionStrings[connStrNameInCnfig].ConnectionString;
            connStr = ReplaceWithCurrentLocation(connStr);
            return connStr;
        }

        private static string ReplaceWithCurrentLocation(string connStr)
        {
            string str = AppDomain.CurrentDomain.BaseDirectory;
            string directryAboveBin = str.Substring(0, str.IndexOf("\\bin"));
            string twoDirectoriesAboveBin = directryAboveBin.Substring(0, directryAboveBin.LastIndexOf("\\"));
            connStr = string.Format(connStr, twoDirectoriesAboveBin);
            return connStr;
        }
    }
}
