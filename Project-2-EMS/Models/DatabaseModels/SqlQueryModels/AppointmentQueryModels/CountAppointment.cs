using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels{
    public class CountAppointment : ICountQuery {
        public int ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(*) FROM Appointments;";

            SqlCountReader reader = new SqlCountReader();

            return reader.Read(command);
        }
    }
}
