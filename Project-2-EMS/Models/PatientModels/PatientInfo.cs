using System;

namespace Project_2_EMS.Models.PatientModels {
    public class PatientInfo : IPatient {
        public int PatientId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public decimal Balance { get; }

        public PatientInfo() { }

        public PatientInfo(int patientId, string firstName, string lastName, string address = null, decimal balance = Decimal.Zero) {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Balance = balance;
        }
    }
}
