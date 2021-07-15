using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlStringsInsert {
        public SqlStringsInsert() { }

        public string GetInsertionString(string queryTable, string queryBy) {
            switch (queryTable.ToLower()) {
                case "appointment":
                    return AppointmentInsertionStrings(queryBy);
                case "patientinfo":
                    return PatientInfoInsertionStrings(queryBy);
                case "prescription":
                    return PrescriptionInsertionStrings(queryBy);
                default:
                    return "";
            }
        }

        private string AppointmentInsertionStrings(string queryBy) {
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

        private string PatientInfoInsertionStrings(string queryBy) {
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

        private string PrescriptionInsertionStrings(string queryBy) {
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
