using System;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class CountQuery : ICountQuery {
        private readonly SqlCommand Command;

        public CountQuery(SqlCommand command) {
            Command = command;
        }

        public SqlCommand ConnectSqlCommand(SqlConnection connection) {
            Command.Connection = connection;

            return Command;
        }
    }
}
