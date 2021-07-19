using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels{
    public class CountAppointment : ISqlQuery, ICountQuery {
        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "SELECT COUNT(*) FROM Appointments;";
        }
    }
}
