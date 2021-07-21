using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class InsertAppointment : INonQuery {
        private readonly PatientAppointment _Appointment;

        public InsertAppointment(PatientAppointment appointment) {
            _Appointment = appointment;
        }

        public void ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "INSERT INTO Appointments ([VisitID], [PatientID], [ApptDate], [ApptTime], [Cost], [ReceptNote], [NurseNote], [DoctorNote]) " +
                                  "VALUES (@visitId,@patientId,@apptDate,@apptTime,@cost,@receptNote,@nurseNote,@doctorNote);";
            command.Parameters.Add("@visitId", SqlDbType.Int).Value = _Appointment.VisitId;
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _Appointment.PatientId;
            command.Parameters.Add("@apptDate", SqlDbType.Date).Value = _Appointment.ApptDate;
            command.Parameters.Add("@apptTime", SqlDbType.Time).Value = _Appointment.ApptTime;
            command.Parameters.Add("@cost", SqlDbType.Decimal).Value = _Appointment.Cost;
            command.Parameters.Add("@receptNote", SqlDbType.Text).Value = _Appointment.ReceptNote;
            command.Parameters.Add("@nurseNote", SqlDbType.Text).Value = _Appointment.NurseNote;
            command.Parameters.Add("@doctorNote", SqlDbType.Text).Value = _Appointment.DoctorNote;

            _ = command.ExecuteNonQuery();
        }
    }
}
