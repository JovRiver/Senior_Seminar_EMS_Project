using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPatientInfoBy_FullName_OR<T> : IListQuery<T> where T : PatientInfo {
        private readonly string _FirstName;
        private readonly string _LastName;

        public SelectPatientInfoBy_FullName_OR(string firstName, string lastName) {
            _FirstName = firstName;
            _LastName = lastName;
        }

        public SqlCommand SetupSqlCommand(SqlConnection connection) {
            SqlCommand command = new SqlCommand() {
                Connection = connection,
                CommandText = "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName OR LastName LIKE @lastName;"
            };
            command.Parameters.Add("@firstName", SqlDbType.Text).Value = _FirstName;
            command.Parameters.Add("@lastName", SqlDbType.Text).Value = _LastName;

            return command;
        }
    }
}
