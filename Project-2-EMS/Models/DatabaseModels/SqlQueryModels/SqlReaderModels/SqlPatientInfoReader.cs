using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlPatientInfoReader : ISqlReader {
        public List<Patient> PatientList { get; } = new List<Patient>();

        public void Read(SqlCommand command) {
            using (SqlDataReader dataReader = command.ExecuteReader()) {
                while (dataReader.Read()) {
                    int patientId = dataReader.GetInt32(0);
                    string lastName = dataReader.GetString(1);
                    string firstName = dataReader.GetString(2);
                    string address = dataReader.GetString(3);
                    decimal balance = dataReader.GetDecimal(4);

                    Patient patient = new Patient(patientId, firstName, lastName, address, balance);
                    PatientList.Add(patient);
                }
            }
        }
    }
}
