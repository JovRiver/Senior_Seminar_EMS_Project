using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlAppointmentStrings : ISqlTableStrings {
        private readonly Dictionary<string, string> DeleteDictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, string> SelectDictionary = new Dictionary<string, string>();

        private readonly string QueryBy;

        public SqlAppointmentStrings(string queryBy) {
            DeleteDictionary.Add("delete_visitid", "DELETE FROM Appointments WHERE VisitID = @visitId;");

            SelectDictionary.Add("patientid", "SELECT * FROM Appointments WHERE PatientID = @patientId;");
            SelectDictionary.Add("date_patientid", "SELECT * FROM Appointments WHERE ApptDate = @apptDate AND PatientID = @patientId;");
            SelectDictionary.Add("visitid", "SELECT * FROM Appointments WHERE VisitID = @visitId;");
            SelectDictionary.Add("daterange", "SELECT * FROM Appointments WHERE ApptDate BETWEEN @apptStartDate AND @apptEndDate;");
            SelectDictionary.Add("count", "SELECT COUNT(*) FROM Appointments;");

            QueryBy = queryBy;
        }

        public string DeleteString() => DeleteDictionary.TryGetValue(QueryBy, out string queryString) ? queryString : "";

        public string InsertString() {
            return "INSERT INTO Appointments ([VisitID], [PatientID], [ApptDate], [ApptTime], [Cost], [ReceptNote], [NurseNote], [DoctorNote]) VALUES (@visitId,@patientId,@apptDate,@apptTime,@cost,@receptNote,@nurseNote,@doctorNote);";
        }

        public string SelectString() => SelectDictionary.TryGetValue(QueryBy, out string queryString) ? queryString : "";

        public string UpdateString() => "";
    }
}
