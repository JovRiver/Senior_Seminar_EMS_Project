using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_VisitId : ISqlQuery, IAppointmentListQuery {
        private readonly int _VisitId;

        public SelectAppointmentBy_VisitId(int visitId) {
            _VisitId = visitId;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@visitId", SqlDbType.Int).Value = _VisitId;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "SELECT * FROM Appointments WHERE VisitID = @visitId;";
        }
    }
}
