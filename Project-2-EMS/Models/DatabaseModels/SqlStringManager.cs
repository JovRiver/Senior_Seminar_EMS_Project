namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlStringManager {
        public SqlStringManager() { }

        public string GetSQLString(SqlQueryManager queryManager) {
            switch(queryManager.QueryTable.ToLower()) {
                case "appointments":
                    return GetAppointmentString(queryManager);
                case "patientinfo":
                    return GetPatientInfoString(queryManager);
                case "prescription":
                    return GetPrescriptionString(queryManager);
                default:
                    return "";
            }
        }

        private string GetAppointmentString(SqlQueryManager queryManager) {
            switch (queryManager.QueryType.ToLower()) {
                case "delete":
                    return "";
                case "insert":
                    return "";
                case "select":
                    return "";
                case "update":
                    return "";
                default:
                    return "";
            }
        }

        private string GetPatientInfoString(SqlQueryManager queryManager) {
            switch (queryManager.QueryType.ToLower()) {
                case "delete":
                    return "";
                case "insert":
                    return "";
                case "select":
                    return "";
                case "update":
                    return "";
                default:
                    return "";
            }
        }

        private string GetPrescriptionString(SqlQueryManager queryManager) {
            switch (queryManager.QueryType.ToLower()) {
                case "delete":
                    return "";
                case "insert":
                    return "";
                case "select":
                    return "";
                case "update":
                    return "";
                default:
                    return "";
            }
        }
    }
}
