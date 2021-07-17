using Project_2_EMS.Models.PatientModels;
using System;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCommandParameters {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }
        public decimal Cost { get; set; }

        public PatientModels.Patient Patient { get; set; }
        public PatientAppointment Appointment { get; set; }
        public PatientPrescription Prescription { get; set; }
    
        public SqlCommandParameters() {
            FirstName = string.Empty;
            LastName = string.Empty;
            FirstDate = DateTime.MinValue;
            SecondDate = DateTime.MinValue;
            Cost = decimal.Zero;

            Patient = new PatientModels.Patient();
            Appointment = new PatientAppointment();
            Prescription = new PatientPrescription();
        }
    }
}
