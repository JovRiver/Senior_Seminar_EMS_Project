namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlStringsUpdate {
        public SqlStringsUpdate() { }

        public string GetUpdateString(string queryTable, string queryBy) {
            switch (queryTable.ToLower()) {
                case "appointment":
                    return AppointmentUpdateStrings(queryBy);
                case "patientinfo":
                    return PatientInfoUpdateStrings(queryBy);
                case "prescription":
                    return PrescriptionUpdateStrings(queryBy);
                default:
                    return "";
            }
        }

        private string AppointmentUpdateStrings(string queryBy) {
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

        private string PatientInfoUpdateStrings(string queryBy) {
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

        private string PrescriptionUpdateStrings(string queryBy) {
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
