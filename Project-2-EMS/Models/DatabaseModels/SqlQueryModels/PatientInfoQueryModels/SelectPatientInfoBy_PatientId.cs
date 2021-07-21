using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPatientInfoBy_PatientId : IListQuery {
        private readonly int _PatientId;

        public SelectPatientInfoBy_PatientId(int patientId) {
            _PatientId = patientId;
        }

        public List<T> ExecuteQuery<T>(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "SELECT * FROM PatientInfo WHERE PatientID = @patientId;";
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _PatientId;

            List<PatientInfo> list = new List<PatientInfo>();
            SqlListReader reader = new SqlListReader();

            reader.Read(command, list);

            return list as List<T>;
        }
    }
}
