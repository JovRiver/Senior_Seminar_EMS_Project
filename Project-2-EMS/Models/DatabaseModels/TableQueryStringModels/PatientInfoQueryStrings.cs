using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels {
    public class PatientInfoQueryStrings : ITableQueryStrings {
        private readonly Dictionary<string, string> SelectDictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, string> UpdateDictionary = new Dictionary<string, string>();

        public PatientInfoQueryStrings() {
            SelectDictionary.Add("full_name_and", "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName AND LastName LIKE @lastName;");
            SelectDictionary.Add("full_name_or", "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName OR LastName LIKE @lastName;");
            SelectDictionary.Add("name_or", "SELECT * FROM PatientInfo WHERE FirstName LIKE @name OR LastName LIKE @name");
            SelectDictionary.Add("patientid", "SELECT * FROM PatientInfo WHERE PatientID = @patientId;");
            SelectDictionary.Add("count", "SELECT COUNT(*) FROM PatientInfo;");

            UpdateDictionary.Add("update_balance", "UPDATE PatientInfo SET Balance = Balance + @cost FROM PatientInfo WHERE PatientID = @patientId;");
        }

        public string Delete(string queryBy) {
            return "";
        }

        public string Insert() {
            return "INSERT INTO PatientInfo ([PatientID], [LastName], [FirstName], [Address], [Balance]) VALUES (@patientId,@lastName,@firstName,@address,@balance);";
        }

        public string Select(string queryBy) {
            return SelectDictionary.TryGetValue(queryBy, out string queryString) ? queryString : "";
        }

        public string Update(string queryBy) {
            return UpdateDictionary.TryGetValue(queryBy, out string queryString) ? queryString : "";
        }
    }
}
