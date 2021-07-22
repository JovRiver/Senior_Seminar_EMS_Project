using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_VisitId<T> : IListQuery<T> where T: PatientAppointment {
        private readonly int _VisitId;

        public SelectAppointmentBy_VisitId(int visitId) {
            _VisitId = visitId;
        }

        public SqlCommand SetupSqlCommand(SqlConnection connection) {
            SqlCommand command = new SqlCommand() {
                Connection = connection,
                CommandText = "SELECT * FROM Appointments WHERE VisitID = @visitId;"
            };
            command.Parameters.Add("@visitId", SqlDbType.Int).Value = _VisitId;

            return command;
        }
    }
}
