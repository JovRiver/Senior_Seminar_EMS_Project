using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPrescriptionBy_PatientId : ISqlQuery, IPrescriptionListQuery {
        private readonly int _PatientId;

        public SelectPrescriptionBy_PatientId(int patientId) {
            _PatientId = patientId;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _PatientId;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "SELECT * FROM Prescription WHERE PatientID = @patientId;";
        }
    }
}
