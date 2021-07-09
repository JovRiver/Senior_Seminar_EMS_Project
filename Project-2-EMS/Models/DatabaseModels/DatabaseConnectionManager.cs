using System.Data.SqlClient;
using System.Configuration;

// I referenced this in creating this class
// https://stackoverflow.com/questions/15174601/in-c-sharp-global-connection-to-be-used-in-all-classes

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseConnectionManager {
        public DatabaseConnectionManager() { }

        private string GetDBConnectionString() {
            return ConfigurationManager.ConnectionStrings["MDR_ConnStr"].ConnectionString;
        }

        public SqlConnection ConnectToDatabase() {
            return new SqlConnection(GetDBConnectionString());
        }
    }
}