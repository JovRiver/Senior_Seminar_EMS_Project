using System;

namespace Project_2_EMS.Models.PatientModels {
    public class PatientPrescription : IPatient {
        public int PrescriptionId { get; }
        public int PatientId { get; }
        public int VisitId { get; }
        public String PrescriptionName { get; }
        public String PrescriptionNotes { get; }
        public int Refills { get; }

        public PatientPrescription() { }

        public PatientPrescription(int prescriptionId, int patientId, int visitId, String prescriptionName, String presciprtionNotes, int refills) {
            PrescriptionId = prescriptionId;
            PatientId = patientId;
            VisitId = visitId;
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
