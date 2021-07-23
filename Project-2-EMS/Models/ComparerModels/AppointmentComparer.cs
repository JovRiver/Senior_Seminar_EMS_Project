using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS.Models.ComparerModels {
    public class AppointmentComparer : IComparer<PatientAppointment> {
        public int Compare(PatientAppointment x, PatientAppointment y) {
            return x.VisitId - y.VisitId;
        }
    }
}
