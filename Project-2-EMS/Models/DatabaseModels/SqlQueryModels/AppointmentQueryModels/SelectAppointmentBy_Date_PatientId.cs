using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_Date_PatientId : ISqlQuery, ISqlCommandParameters, IAppointmentListQuery {
        private readonly DateTime _AppointmentDate;
        private readonly int _PatientId;

        public SelectAppointmentBy_Date_PatientId(DateTime appointmentDate, int patientId) {
            _AppointmentDate = appointmentDate;
            _PatientId = patientId;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@apptDate", SqlDbType.DateTime).Value = _AppointmentDate;
            command.Parameters.Add("@patientID", SqlDbType.Int).Value = _PatientId;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "SELECT * FROM Appointments WHERE ApptDate = @apptDate AND PatientID = @patientId;";
        }
    }
}
