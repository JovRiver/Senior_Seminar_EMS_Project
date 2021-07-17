using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlPatientInfoStrings : ISqlTableStrings {
        private readonly Dictionary<string, string> SelectDictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, string> UpdateDictionary = new Dictionary<string, string>();

        private readonly string QueryBy;

        public SqlPatientInfoStrings(string queryBy) {
            SelectDictionary.Add("full_name_and", "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName AND LastName LIKE @lastName;");
            SelectDictionary.Add("full_name_or", "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName OR LastName LIKE @lastName;");
            SelectDictionary.Add("name_or", "SELECT * FROM PatientInfo WHERE FirstName LIKE @name OR LastName LIKE @name");
            SelectDictionary.Add("patientid", "SELECT * FROM PatientInfo WHERE PatientID = @patientId;");
            SelectDictionary.Add("count", "SELECT COUNT(*) FROM PatientInfo;");

            UpdateDictionary.Add("update_balance", "UPDATE PatientInfo SET Balance = Balance + @cost FROM PatientInfo WHERE PatientID = @patientId;");

            QueryBy = queryBy;
        }

        public string DeleteString() => "";

        public string InsertString() {
            return "INSERT INTO PatientInfo ([PatientID], [LastName], [FirstName], [Address], [Balance]) VALUES (@patientId,@lastName,@firstName,@address,@balance);";
        }

        public string SelectString() => SelectDictionary.TryGetValue(QueryBy, out string queryString) ? queryString : "";

        public string UpdateString() => UpdateDictionary.TryGetValue(QueryBy, out string queryString) ? queryString : "";
    }
}
