using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS.Models.ComparerModels {
    public class PrescriptionComparer : IComparer<PatientPrescription> {
        public int Compare(PatientPrescription x, PatientPrescription y) {
            return x.PrescriptionId - y.PrescriptionId;
        }
    }
}
