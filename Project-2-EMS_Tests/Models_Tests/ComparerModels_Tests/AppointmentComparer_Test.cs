using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_2_EMS.Models.ComparerModels;
using Project_2_EMS.Models.PatientModels;
using System;

namespace Project_2_EMS_Tests.Models_Tests.ComparerModels_Tests {
    /// 
    /// Test that the AppointmentComparer correctly compares two appointments
    /// 
    [TestClass]
    public class AppointmentComparer_Test {
        [TestMethod]
        // Test when two appointments are equal (by VisitId)
        public void AppointmentComparer_Equal_Test() {
            PatientAppointment appointment_One = new PatientAppointment(1, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "");
            PatientAppointment appointment_Two = new PatientAppointment(1, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "");

            AppointmentComparer appointmentComparer = new AppointmentComparer();

            Assert.IsTrue(appointmentComparer.Compare(appointment_One, appointment_Two) == 0);
        }

        [TestMethod]
        // Test when two appointments are not equal (by VisitId)
        public void AppointmentComparer_NotEqual_Test() {
            PatientAppointment appointment_One = new PatientAppointment(1, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "");
            PatientAppointment appointment_Two = new PatientAppointment(2, 2, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "");

            AppointmentComparer appointmentComparer = new AppointmentComparer();

            Assert.IsTrue(appointmentComparer.Compare(appointment_One, appointment_Two) != 0);
        }
    }
}
