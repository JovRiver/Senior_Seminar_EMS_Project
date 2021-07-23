using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS.Models.ComparerModels {
    public class PatientInfoComparer : IComparer<PatientInfo> {
        public int Compare(PatientInfo x, PatientInfo y) {
            return x.PatientId - y.PatientId;
        }
    }
}
