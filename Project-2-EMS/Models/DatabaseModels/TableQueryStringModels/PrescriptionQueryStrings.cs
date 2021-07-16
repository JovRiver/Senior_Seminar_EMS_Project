using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels {
    public class PrescriptionQueryStrings : ITableQueryStrings {
        private readonly Dictionary<string, string> SelectDictionary = new Dictionary<string, string>();

        public PrescriptionQueryStrings() {
            SelectDictionary.Add("patientid", "SELECT * FROM Prescription WHERE PatientID = @patientId;");
            SelectDictionary.Add("visitid", "SELECT * FROM Prescription WHERE VisitID = @visitId;");
            SelectDictionary.Add("count", "SELECT COUNT(*) FROM Prescription;");
        }

        public string Delete(string queryBy) {
            return "";
        }

        public string Insert() {
            return "INSERT INTO Prescription ([PrescriptionID], [PatientID], [VisitID], [PrescriptionName], [PrescriptionNotes], [Refills]) VALUES (@prescriptionId,@patientId,@visitId,@prescriptionName,@prescriptionNotes,@refills);";
        }

        public string Select(string queryBy) {
            return SelectDictionary.TryGetValue(queryBy, out string queryString) ? queryString : "";
        }

        public string Update(string queryBy) {
            return "";
        }
    }
}
