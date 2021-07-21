using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectPrescriptionBy_VisitId<T> : IListQuery<T> where T: PatientPrescription {
        private readonly int _VisitId;

        public SelectPrescriptionBy_VisitId(int visitId) {
            _VisitId = visitId;
        }

        public List<T> ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Prescription WHERE VisitID = @visitId;";
            command.Parameters.Add("@visitId", SqlDbType.Int).Value = _VisitId;

            List<PatientPrescription> list = new List<PatientPrescription>();
            SqlListReader reader = new SqlListReader();

            reader.Read(command, list);

            return list as List<T>;
        }
    }
}
