using Project_2_EMS.Models.PatientModels;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class PrescriptionQuery<T> where T : PatientPrescription {
        private SqlCommand Command;

        public ICountQuery Count() {
            Command = new SqlCommand() {
                CommandText = "SELECT COUNT(*) FROM Prescription;"
            };

            return new CountQuery(Command);
        }

        public INonQuery Insert(PatientPrescription prescription) {
            Command = new SqlCommand() {
                CommandText = "INSERT INTO Prescription ([PrescriptionID], [PatientID], [VisitID], [PrescriptionName], [PrescriptionNotes], [Refills]) " +
                              "VALUES (@prescriptionId,@patientId,@visitId,@prescriptionName,@prescriptionNotes,@refills);"
            };
            Command.Parameters.Add("@prescriptionID", SqlDbType.Int).Value = prescription.PrescriptionId;
            Command.Parameters.Add("@patientID", SqlDbType.Int).Value = prescription.PatientId;
            Command.Parameters.Add("@visitID", SqlDbType.Int).Value = prescription.VisitId;
            Command.Parameters.Add("@prescriptionName", SqlDbType.Text).Value = prescription.PrescriptionName;
            Command.Parameters.Add("@prescriptionNotes", SqlDbType.Text).Value = prescription.PrescriptionNotes;
            Command.Parameters.Add("@refills", SqlDbType.TinyInt).Value = prescription.Refills;

            return new NonQuery(Command);
        }

        public ISelectQuery<T> SelectBy_PatientId(int patientId) {
            Command = new SqlCommand {
                CommandText = "SELECT * FROM Prescription WHERE PatientID = @patientId;"
            };
            Command.Parameters.Add("@patientId", SqlDbType.Int).Value = patientId;

            return new SelectQuery<T>(Command);
        }

        public ISelectQuery<T> SelectBy_VisitId(int visitid) {
            Command = new SqlCommand {
                CommandText = "SELECT * FROM Prescription WHERE VisitID = @visitId;"
            };
            Command.Parameters.Add("@visitId", SqlDbType.Int).Value = visitid;

            return new SelectQuery<T>(Command);
        }
    }
}
