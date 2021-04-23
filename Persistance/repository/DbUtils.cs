using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace mpp_proiect_csharp.Persistance
{
    public class DbUtils
    {

        private static IDbConnection instance = null;

        public static IDbConnection getConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;

        }

        private static IDbConnection getNewConnection()
        {
            String connectionString = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["transportAgencyDB"];
            if (settings != null)
                connectionString = settings.ConnectionString;     
            return new SQLiteConnection(connectionString); 
        }
    }

}
