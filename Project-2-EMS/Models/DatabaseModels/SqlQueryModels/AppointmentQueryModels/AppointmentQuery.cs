using Project_2_EMS.Models.PatientModels;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class AppointmentQuery<T> where T : PatientAppointment {
        private SqlCommand Command;

        public AppointmentQuery() { }

        public ISqlCount Count() {
            Command = new SqlCommand() {
                CommandText = "SELECT COUNT(*) FROM Appointments;"
            };

            return new SqlCountParameters(Command);
        }

        public ISqlNonQuery DeleteBy_VisitId(int visitId) {
            Command = new SqlCommand() {
                CommandText = "DELETE FROM Appointments WHERE VisitID = @visitId;"
            };
            Command.Parameters.Add("@visitId", SqlDbType.Int).Value = visitId;

            return new SqlNonQueryParameters(Command);
        }

        public ISqlNonQuery Insert(PatientAppointment appointment) {
            Command = new SqlCommand() {
                CommandText = "INSERT INTO Appointments ([VisitID], [PatientID], [ApptDate], [ApptTime], [Cost], [ReceptNote], [NurseNote], [DoctorNote]) " +
                              "VALUES (@visitId,@patientId,@apptDate,@apptTime,@cost,@receptNote,@nurseNote,@doctorNote);"
            };
            Command.Parameters.Add("@visitId", SqlDbType.Int).Value = appointment.VisitId;
            Command.Parameters.Add("@patientId", SqlDbType.Int).Value = appointment.PatientId;
            Command.Parameters.Add("@apptDate", SqlDbType.Date).Value = appointment.ApptDate;
            Command.Parameters.Add("@apptTime", SqlDbType.Time).Value = appointment.ApptTime;
            Command.Parameters.Add("@cost", SqlDbType.Decimal).Value = appointment.Cost;
            Command.Parameters.Add("@receptNote", SqlDbType.Text).Value = appointment.ReceptNote;
            Command.Parameters.Add("@nurseNote", SqlDbType.Text).Value = appointment.NurseNote;
            Command.Parameters.Add("@doctorNote", SqlDbType.Text).Value = appointment.DoctorNote;

            return new SqlNonQueryParameters(Command);
        }

        public ISqlSelect<T> SelectBy_Date_PatientId(DateTime appointmentDate, int patientId) {
            Command = new SqlCommand() {
                CommandText = "SELECT * FROM Appointments WHERE ApptDate = @apptDate AND PatientID = @patientId;"
            };
            Command.Parameters.Add("@apptDate", SqlDbType.DateTime).Value = appointmentDate;
            Command.Parameters.Add("@patientID", SqlDbType.Int).Value = patientId;

            return new SqlSelectParameters<T>(Command);
        }

        public ISqlSelect<T> SelectBy_DateRange(DateTime startDate, DateTime endDate) {
            Command = new SqlCommand() {
                CommandText = "SELECT * FROM Appointments WHERE ApptDate BETWEEN @apptStartDate AND @apptEndDate;"
            };
            Command.Parameters.Add("@ApptStartDate", SqlDbType.DateTime).Value = startDate;
            Command.Parameters.Add("@ApptEndDate", SqlDbType.DateTime).Value = endDate;

            return new SqlSelectParameters<T>(Command);
        }

        public ISqlSelect<T> SelectBy_PatientId(int patientId) {
            Command = new SqlCommand() { 
                CommandText = "SELECT * FROM Appointments WHERE PatientID = @patientId;"
            };
            Command.Parameters.Add("@patientId", SqlDbType.Int).Value = patientId;

            return new SqlSelectParameters<T>(Command);
        }

        public ISqlSelect<T> SelectBy_VisitId(int visitId) {
            Command = new SqlCommand() { 
                CommandText = "SELECT * FROM Appointments WHERE VisitID = @visitId;" 
            };
            Command.Parameters.Add("@visitId", SqlDbType.Int).Value = visitId;

            return new SqlSelectParameters<T>(Command);
        }
    }
}
