using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryListManager {
        public List<PatientAppointment> Appointments { get; }
        public List<Patient> Patients { get; }
        public List<PatientPrescription> Prescriptions { get; }

        public DatabaseQueryListManager() { }

        public DatabaseQueryListManager(List<PatientAppointment> appointments) : this(appointments, null, null) { }
        public DatabaseQueryListManager(List<Patient> patients) : this(null, patients, null) { }
        public DatabaseQueryListManager(List<PatientPrescription> prescriptions) : this(null, null, prescriptions) { }

        public DatabaseQueryListManager(List<PatientAppointment> appointments, List<Patient> patients, List<PatientPrescription> prescriptions) {
            Appointments = appointments;
            Patients = patients;
            Prescriptions = prescriptions;
        }
    }
}
