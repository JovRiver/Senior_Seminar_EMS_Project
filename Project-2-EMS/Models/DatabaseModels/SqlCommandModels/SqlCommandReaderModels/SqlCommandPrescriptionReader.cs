using Project_2_EMS.Models.PatientModels;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCommandPrescriptionReader : ISqlCommandTableReader {
        public void Read(SqlCommand command, ListManager listManager) {
            using (SqlDataReader dataReader = command.ExecuteReader()) {
                while (dataReader.Read()) {
                    int prescriptionId = dataReader.GetInt32(0);
                    int patientId = dataReader.GetInt32(1);
                    int visitId = dataReader.GetInt32(2);
                    string prescriptionName = dataReader.GetString(3);
                    string prescriptionNotes = dataReader.GetString(4);
                    byte refills = dataReader.GetByte(5);

                    PatientPrescription prescription = new PatientPrescription(prescriptionId, patientId, visitId, prescriptionName, prescriptionNotes, refills);
                    listManager.PrescriptionList.Add(prescription);
                }
            }
        }
    }
}
