using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class CountPrescription : ICountQuery { 
        public int ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(*) FROM Prescription;";

            SqlCountReader reader = new SqlCountReader();

            return reader.Read(command);
        }
    }
}
