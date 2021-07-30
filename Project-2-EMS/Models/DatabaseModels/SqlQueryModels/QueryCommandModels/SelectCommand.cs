using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectCommand<T> : ISelectCommand<T> {
        private readonly SqlCommand Command;

        public SelectCommand(SqlCommand command) {
            Command = command;
        }

        public SqlCommand ConnectSqlCommand(SqlConnection connection) {
            Command.Connection = connection;
            return Command;
        }
    }
}
