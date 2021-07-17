using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels{
    public class ListManager {
        public List<Patient> PatientList { get; set; } = new List<Patient>();
        public List<PatientAppointment> AppointmentList { get; set; } = new List<PatientAppointment>();
        public List<PatientPrescription> PrescriptionList { get; set; } = new List<PatientPrescription>();

        public ListManager() { }
    }
}
