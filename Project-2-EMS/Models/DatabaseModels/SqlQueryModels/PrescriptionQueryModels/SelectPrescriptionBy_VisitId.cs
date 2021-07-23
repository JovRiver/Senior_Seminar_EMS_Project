using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPrescriptionBy_VisitId<T> : IListQuery<T> where T : PatientPrescription {
        private readonly int _VisitId;

        public SelectPrescriptionBy_VisitId(int visitId) {
            _VisitId = visitId;
        }

        public SqlCommand SetupSqlCommand(SqlConnection connection) {
            SqlCommand command = new SqlCommand {
                Connection = connection,
                CommandText = "SELECT * FROM Prescription WHERE VisitID = @visitId;"
            };
            command.Parameters.Add("@visitId", SqlDbType.Int).Value = _VisitId;

            return command;
        }
    }
}
