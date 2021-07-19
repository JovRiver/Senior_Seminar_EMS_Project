using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class InsertPatientInfo : ISqlQuery, INonQuery {
        private readonly Patient _Patient;

        public InsertPatientInfo(Patient patient) {
            _Patient = patient;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@patientId", SqlDbType.Int).Value = _Patient.PatientId;
            command.Parameters.Add("@lastName", SqlDbType.Text).Value = _Patient.LastName;
            command.Parameters.Add("@firstName", SqlDbType.Text).Value = _Patient.FirstName;
            command.Parameters.Add("@address", SqlDbType.Text).Value = _Patient.Address;
            command.Parameters.Add("@balance", SqlDbType.Decimal).Value = _Patient.Balance;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "INSERT INTO PatientInfo ([PatientID], [LastName], [FirstName], [Address], [Balance]) " +
                   "VALUES (@patientId,@lastName,@firstName,@address,@balance);";
        }
    }
}
