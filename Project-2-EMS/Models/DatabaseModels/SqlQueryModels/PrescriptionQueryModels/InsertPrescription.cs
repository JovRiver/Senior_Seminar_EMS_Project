using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class InsertPrescription : INonQuery {
        private readonly PatientPrescription _Prescription;

        public InsertPrescription(PatientPrescription prescription) {
            _Prescription = prescription;
        }

        public void ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "INSERT INTO Prescription ([PrescriptionID], [PatientID], [VisitID], [PrescriptionName], [PrescriptionNotes], [Refills]) " +
                                  "VALUES (@prescriptionId,@patientId,@visitId,@prescriptionName,@prescriptionNotes,@refills);";
            command.Parameters.Add("@prescriptionID", SqlDbType.Int).Value = _Prescription.PrescriptionID;
            command.Parameters.Add("@patientID", SqlDbType.Int).Value = _Prescription.PatientID;
            command.Parameters.Add("@visitID", SqlDbType.Int).Value = _Prescription.VisitID;
            command.Parameters.Add("@prescriptionName", SqlDbType.Text).Value = _Prescription.PrescriptionName;
            command.Parameters.Add("@prescriptionNotes", SqlDbType.Text).Value = _Prescription.PrescriptionNotes;
            command.Parameters.Add("@refills", SqlDbType.TinyInt).Value = _Prescription.Refills;

            _ = command.ExecuteNonQuery();
        }
    }
}
