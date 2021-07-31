using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class CountCommand : ICountCommand {
        private readonly SqlCommand Command;

        public CountCommand(SqlCommand command) {
            Command = command;
        }

        public SqlCommand ConnectSqlCommand(SqlConnection connection) {
            Command.Connection = connection;
            return Command;
        }
    }
}
