using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPatientInfoBy_FullName_AND<T> : IListQuery<T> where T : PatientInfo {
        private readonly string _FirstName;
        private readonly string _LastName;

        public SelectPatientInfoBy_FullName_AND(string firstName, string lastName) {
            _FirstName = firstName;
            _LastName = lastName;
        }

        public List<T> ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName AND LastName LIKE @lastName;";
            command.Parameters.Add("@firstName", SqlDbType.Text).Value = _FirstName;
            command.Parameters.Add("@lastName", SqlDbType.Text).Value = _LastName;

            List<PatientInfo> list = new List<PatientInfo>();
            SqlListReader reader = new SqlListReader();

            reader.Read(command, list);

            return list as List<T>;
        }
    }
}
