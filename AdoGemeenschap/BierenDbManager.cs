using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

namespace AdoGemeenschap
{
    public class BierenDbManager
    {
        private static ConnectionStringSettings conBierenSettings = ConfigurationManager.ConnectionStrings["Bieren"];
        private static DbProviderFactory factory = DbProviderFactories.GetFactory(conBierenSettings.ProviderName);

        public DbConnection GetConnection()
        {
            var conBieren = factory.CreateConnection();
            conBieren.ConnectionString = conBierenSettings.ConnectionString;
            return conBieren;
        }
    }
}
