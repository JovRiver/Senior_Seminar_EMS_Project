using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectQuery<T> : ISelectQuery<T> {
        private readonly SqlCommand Command;

        public SelectQuery(SqlCommand command) {
            Command = command;
        }

        public SqlCommand ConnectSqlCommand(SqlConnection connection) {
            Command.Connection = connection;

            return Command;
        }
    }
}
