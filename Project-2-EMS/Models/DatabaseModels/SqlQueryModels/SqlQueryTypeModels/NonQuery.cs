using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class NonQuery : INonQuery {
        private readonly SqlCommand Command;

        public NonQuery(SqlCommand command) {
            Command = command;
        }
        
        public SqlCommand ConnectSqlCommand(SqlConnection connection) {
            Command.Connection = connection;

            return Command;
        }
    }
}
