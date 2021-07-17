using System;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCommandManager {

        public SqlCommandManager() { }

        public SqlCommand CreateCommandWithParameters(string queryString, SqlConnection connection, SqlCommandParameters parameters) {
            SqlCommand command = new SqlCommand(queryString, connection);

            return command;
        }
    }
}
