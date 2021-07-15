namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlStringsDelete {

        public SqlStringsDelete() { }

        public string GetDeletionString(string queryTable, string queryBy) {
            switch(queryTable.ToLower()) {
                case "appointment":
                    return AppointmentDeletionStrings(queryBy);
                case "patientinfo":
                    return PatientInfoDeletionStrings(queryBy);
                case "prescription":
                    return PrescriptionDeletionStrings(queryBy);
                default:
                    return "";
            }
        }

        private string AppointmentDeletionStrings(string queryBy) {
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

        private string PatientInfoDeletionStrings(string queryBy) {
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

        private string PrescriptionDeletionStrings(string queryBy) {
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
