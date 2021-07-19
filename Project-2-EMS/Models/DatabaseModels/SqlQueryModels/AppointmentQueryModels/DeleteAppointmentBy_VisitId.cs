using System.Data.SqlClient;
using System.Data;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DeleteAppointmentBy_VisitId : ISqlQuery, ISqlCommandParameters, INonQuery {
        private readonly int _VisitId;

        public DeleteAppointmentBy_VisitId(int visitId) {
            _VisitId = visitId;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@visitId", SqlDbType.Int).Value = _VisitId;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "DELETE FROM Appointments WHERE VisitID = @visitId;";
        }
    }
}
