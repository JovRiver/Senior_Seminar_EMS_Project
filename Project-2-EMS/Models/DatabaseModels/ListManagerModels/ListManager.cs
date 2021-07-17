using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels{
    public class ListManager {
        public List<Patient> PatientList { get; set; }
        public List<PatientAppointment> AppointmentList { get; set; }
        public List<PatientPrescription> PrescriptionList { get; set; }

        public ListManager() { }
    }
}
