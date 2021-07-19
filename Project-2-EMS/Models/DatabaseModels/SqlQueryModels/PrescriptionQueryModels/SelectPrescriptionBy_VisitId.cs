using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPrescriptionBy_VisitId : ISqlQuery, ISqlCommandParameters, IPrescriptionListQuery {
        private readonly int _VisitId;

        public SelectPrescriptionBy_VisitId(int visitId) {
            _VisitId = visitId;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@visitId", SqlDbType.Int).Value = _VisitId;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "SELECT * FROM Prescription WHERE VisitID = @visitId;";
        }
    }
}
