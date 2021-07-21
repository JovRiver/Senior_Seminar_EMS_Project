using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_PatientId<T> : IListQuery<T> where T : PatientAppointment {
        private readonly int _PatientId;

        public SelectAppointmentBy_PatientId(int patientId) {
            _PatientId = patientId;
        }

        public List<T> ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Appointments WHERE PatientID = @patientId;";
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _PatientId;

            List<PatientAppointment> list = new List<PatientAppointment>();
            SqlListReader reader = new SqlListReader();

            reader.Read(command, list);

            return list as List<T>;
        }
    }
}
