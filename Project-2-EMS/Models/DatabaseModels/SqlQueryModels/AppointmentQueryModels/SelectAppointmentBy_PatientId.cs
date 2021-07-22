using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_PatientId<T> : IListQuery<T> where T : PatientAppointment {
        private readonly int _PatientId;

        public SelectAppointmentBy_PatientId(int patientId) {
            _PatientId = patientId;
        }

        public SqlCommand SetupSqlCommand(SqlConnection connection) {
            SqlCommand command = new SqlCommand() {
                Connection = connection,
                CommandText = "SELECT * FROM Appointments WHERE PatientID = @patientId;"
            };
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _PatientId;

            return command;
        }
    }
}
