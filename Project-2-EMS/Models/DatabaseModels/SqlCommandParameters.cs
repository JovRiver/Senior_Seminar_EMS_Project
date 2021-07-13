using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCommandParameters {
        public int PatientId { get; }
        public int VisitId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Cost { get; }

        public SqlCommandParameters(int patientId) {
            PatientId = patientId;
        }

        public SqlCommandParameters(String firstName, String lastName) {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
