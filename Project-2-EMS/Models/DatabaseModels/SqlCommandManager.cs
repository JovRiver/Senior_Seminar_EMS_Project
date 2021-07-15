using System;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCommandManager {

        public SqlCommandManager() { }

        public SqlCommand CreateCommandWithParameters(SqlCommandParameters parameters, SqlConnection connection, SqlQueryManager queryManager) {
            SqlCommand command = new SqlCommand();

            return command;
        }
    }
}
