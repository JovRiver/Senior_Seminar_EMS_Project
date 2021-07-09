using System;

namespace Project_2_EMS.Models.PatientModels {
    public class PatientPrescription {
        public int PrescriptionID { get; }
        public int PatientID { get; }
        public int VisitID { get; }
        public String PrescriptionName { get; }
        public String PrescriptionNotes { get; }
        public int Refills { get; }

        public PatientPrescription(int prescriptionID, int patientID, int visitID, String prescriptionName, String presciprtionNotes, int refills) {
            PrescriptionID = prescriptionID;
            PatientID = patientID;
            VisitID = visitID;
            PrescriptionName = prescriptionName;
            PrescriptionNotes = presciprtionNotes;
            Refills = refills;

        }

        public override string ToString() {
            return "Prescription Name: " + PrescriptionName +
                   "\n Doctor's Notes: " + PrescriptionNotes +
                   "\n Refills Remaining: " + Refills + "\n\n\n";
        }
    }
}
