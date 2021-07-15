using System;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlStringsSelect {
        public SqlStringsSelect() { }

        public string GetSelectString(string queryTable, string queryBy) {
            switch (queryTable.ToLower()) {
                case "appointment":
                    return AppointmentSelectStrings(queryBy);
                case "patientinfo":
                    return PatientInfoSelectStrings(queryBy);
                case "prescription":
                    return PrescriptionSelectStrings(queryBy);
                default:
                    return "";
            }
        }
        
        private string AppointmentSelectStrings(string queryBy) {
            switch (queryBy.ToLower()) {
                case "patientid":
                    return "";
                case "visitid":
                    return "";
                case "date":
                    return "";
                case "daterange":
                    return "";
                case "name":
                    return "";
                case "none":
                    return "";
                default:
                    return "";
            }
        }

        private string PatientInfoSelectStrings(string queryBy) {
            switch (queryBy.ToLower()) {
                case "patientid":
                    return "";
                case "visitid":
                    return "";
                case "daterange":
                    return "";
                case "name":
                    return "";
                case "none":
                    return "";
                default:
                    return "";
            }
        }

        private string PrescriptionSelectStrings(string queryBy) {
            switch (queryBy.ToLower()) {
                case "patientid":
                    return "";
                case "visitid":
                    return "";
                case "daterange":
                    return "";
                case "name":
                    return "";
                case "none":
                    return "";
                default:
                    return "";
            }
        }
    }
}
