using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPatientInfoBy_PatientId : ISqlQuery, IPatientInfoListQuery {
        private readonly int _PatientId;

        public SelectPatientInfoBy_PatientId(int patientId) {
            _PatientId = patientId;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _PatientId;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "SELECT * FROM PatientInfo WHERE PatientID = @patientId;";
        }
    }
}
