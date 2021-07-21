using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class InsertPatientInfo : INonQuery {
        private readonly PatientInfo _Patient;

        public InsertPatientInfo(PatientInfo patient) {
            _Patient = patient;
        }

        public void ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "INSERT INTO PatientInfo ([PatientID], [LastName], [FirstName], [Address], [Balance]) " +
                                  "VALUES (@patientId,@lastName,@firstName,@address,@balance);";
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _Patient.PatientId;
            command.Parameters.Add("@lastName", SqlDbType.Text).Value = _Patient.LastName;
            command.Parameters.Add("@firstName", SqlDbType.Text).Value = _Patient.FirstName;
            command.Parameters.Add("@address", SqlDbType.Text).Value = _Patient.Address;
            command.Parameters.Add("@balance", SqlDbType.Decimal).Value = _Patient.Balance;

            _ = command.ExecuteNonQuery();
        }
    }
}
