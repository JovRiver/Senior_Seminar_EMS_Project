using System.Data;
using System.Data.SqlClient;
namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPatientInfoBy_FullName_AND : ISqlQuery, IPatientInfoListQuery {
        private readonly string _FirstName;
        private readonly string _LastName;

        public SelectPatientInfoBy_FullName_AND(string firstName, string lastName) {
            _FirstName = firstName;
            _LastName = lastName;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@firstName", SqlDbType.Text).Value = _FirstName;
            command.Parameters.Add("@lastName", SqlDbType.Text).Value = _LastName;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName AND LastName LIKE @lastName;";
        }
    }
}
