using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class NonQueryCommand : INonQueryCommand {
        private readonly SqlCommand Command;

        public NonQueryCommand(SqlCommand command) {
            Command = command;
        }
        
        public SqlCommand ConnectSqlCommand(SqlConnection connection) {
            Command.Connection = connection;
            return Command;
        }
    }
}
