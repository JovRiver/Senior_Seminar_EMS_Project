using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCommandManager {

        public SqlCommandManager() { }

        public SqlCommand CreateCommandWithParameters(SqlCommandParameters parameters, String queryTable, String queryBy, SqlConnection connection) {
            SqlCommand command = new SqlCommand();

            return command;
        }
    }
}
