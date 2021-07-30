using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class PatientInfoQuery<T> where T : PatientInfo {
        private SqlCommand Command;

        public ICountCommand Count() {
            Command = new SqlCommand() {
                CommandText = "SELECT COUNT(*) FROM PatientInfo;"
            };

            return new CountCommand(Command);
        }

        public INonQueryCommand Insert(PatientInfo patient) {
            Command = new SqlCommand() {
                CommandText = "INSERT INTO PatientInfo ([PatientID], [LastName], [FirstName], [Address], [Balance]) " +
                              "VALUES (@patientId,@lastName,@firstName,@address,@balance);"
            };
            Command.Parameters.Add("@patientId", SqlDbType.Int).Value = patient.PatientId;
            Command.Parameters.Add("@lastName", SqlDbType.Text).Value = patient.LastName;
            Command.Parameters.Add("@firstName", SqlDbType.Text).Value = patient.FirstName;
            Command.Parameters.Add("@address", SqlDbType.Text).Value = patient.Address;
            Command.Parameters.Add("@balance", SqlDbType.Decimal).Value = patient.Balance;

            return new NonQueryCommand(Command);
        }

        public ISelectCommand<T> SelectBy_FullName_AND(string firstName, string lastName) {
            Command = new SqlCommand() {
                CommandText = "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName AND LastName LIKE @lastName;"
            };
            Command.Parameters.Add("@firstName", SqlDbType.Text).Value = firstName;
            Command.Parameters.Add("@lastName", SqlDbType.Text).Value = lastName;

            return new SelectCommand<T>(Command);
        }

        public ISelectCommand<T> SelectBy_FullName_OR(string firstName, string lastName) {
            Command = new SqlCommand() {
                CommandText = "SELECT * FROM PatientInfo WHERE FirstName LIKE @firstName OR LastName LIKE @lastName;"
            };
            Command.Parameters.Add("@firstName", SqlDbType.Text).Value = firstName;
            Command.Parameters.Add("@lastName", SqlDbType.Text).Value = lastName;

            return new SelectCommand<T>(Command);
        }

        public ISelectCommand<T> SelectBy_PatientId(int patientId) {
            Command = new SqlCommand() {
                CommandText = "SELECT * FROM PatientInfo WHERE PatientID = @patientId;"
            };
            Command.Parameters.Add("@patientId", SqlDbType.Int).Value = patientId;

            return new SelectCommand<T>(Command);
        }

        public INonQueryCommand UpdateBy_Cost_PatientId(decimal cost, int patientId) {
            Command = new SqlCommand() {
                CommandText = "UPDATE PatientInfo SET Balance = Balance + @cost FROM PatientInfo WHERE PatientID = @patientId;"
            };
            Command.Parameters.Add("@cost", SqlDbType.Decimal).Value = cost;
            Command.Parameters.Add("@patientId", SqlDbType.Int).Value = patientId;

            return new NonQueryCommand(Command);
        }
    }
}
