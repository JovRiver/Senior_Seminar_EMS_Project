using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class CountPatientInfo : ICountQuery {
        public SqlCommand SetupSqlCommand(SqlConnection connection) {
            SqlCommand command = new SqlCommand() {
                Connection = connection,
                CommandText = "SELECT COUNT(*) FROM PatientInfo;"
            };

            return command;
        }
    }
}
