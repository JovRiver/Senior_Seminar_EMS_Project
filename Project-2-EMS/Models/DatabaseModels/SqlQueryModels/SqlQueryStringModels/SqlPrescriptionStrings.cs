using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlPrescriptionStrings : ISqlTableStrings {
        private readonly Dictionary<string, string> SelectDictionary = new Dictionary<string, string>();

        private readonly string QueryBy;

        public SqlPrescriptionStrings(string queryBy) {
            SelectDictionary.Add("patientid", "SELECT * FROM Prescription WHERE PatientID = @patientId;");
            SelectDictionary.Add("visitid", "SELECT * FROM Prescription WHERE VisitID = @visitId;");
            SelectDictionary.Add("count", "SELECT COUNT(*) FROM Prescription;");

            QueryBy = queryBy;
        }

        public string DeleteString() => "";

        public string InsertString() {
            return "INSERT INTO Prescription ([PrescriptionID], [PatientID], [VisitID], [PrescriptionName], [PrescriptionNotes], [Refills]) VALUES (@prescriptionId,@patientId,@visitId,@prescriptionName,@prescriptionNotes,@refills);";
        }

        public string SelectString() => SelectDictionary.TryGetValue(QueryBy, out string queryString) ? queryString : "";

        public string UpdateString() => "";
    }
}
