using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class InsertAppointment : ISqlQuery, ISqlCommandParameters, INonQuery {
        private readonly PatientAppointment _Appointment;

        public InsertAppointment(PatientAppointment appointment) {
            _Appointment = appointment;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@visitId", SqlDbType.Int).Value = _Appointment.VisitId;
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _Appointment.PatientId;
            command.Parameters.Add("@apptDate", SqlDbType.Date).Value = _Appointment.ApptDate;
            command.Parameters.Add("@apptTime", SqlDbType.Time).Value = _Appointment.ApptTime;
            command.Parameters.Add("@cost", SqlDbType.Decimal).Value = _Appointment.Cost;
            command.Parameters.Add("@receptNote", SqlDbType.Text).Value = _Appointment.ReceptNote;
            command.Parameters.Add("@nurseNote", SqlDbType.Text).Value = _Appointment.NurseNote;
            command.Parameters.Add("@doctorNote", SqlDbType.Text).Value = _Appointment.DoctorNote;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "INSERT INTO Appointments ([VisitID], [PatientID], [ApptDate], [ApptTime], [Cost], [ReceptNote], [NurseNote], [DoctorNote]) " +
                   "VALUES (@visitId,@patientId,@apptDate,@apptTime,@cost,@receptNote,@nurseNote,@doctorNote);";
        }
    }
}
