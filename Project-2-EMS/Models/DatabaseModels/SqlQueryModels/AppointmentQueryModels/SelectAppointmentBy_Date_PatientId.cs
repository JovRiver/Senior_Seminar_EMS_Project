using Project_2_EMS.Models.PatientModels;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_Date_PatientId<T> : IListQuery<T> where T : PatientAppointment {
        private readonly DateTime _AppointmentDate;
        private readonly int _PatientId;

        public SelectAppointmentBy_Date_PatientId(DateTime appointmentDate, int patientId) {
            _AppointmentDate = appointmentDate;
            _PatientId = patientId;
        }

        public SqlCommand SetupSqlCommand(SqlConnection connection) {
            SqlCommand command = new SqlCommand() {
                Connection = connection,
                CommandText = "SELECT * FROM Appointments WHERE ApptDate = @apptDate AND PatientID = @patientId;"
            };
            command.Parameters.Add("@apptDate", SqlDbType.DateTime).Value = _AppointmentDate;
            command.Parameters.Add("@patientID", SqlDbType.Int).Value = _PatientId;

            return command;
        }
    }
}
