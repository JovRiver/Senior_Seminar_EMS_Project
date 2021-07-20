using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_2_EMS.Models.ComparerModels;
using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_2_EMS_Tests.Models_Tests.ComparerModels_Tests {
    /// 
    /// Test that the PrescriptionComparer correctly compares two prescriptions
    /// 
    [TestClass]
    public class PrescriptionComparer_Test {
        [TestMethod]
        // Test when two prescriptions are equal (by PrescriptionId)
        public void AppointmentComparer_Equal_Test() {
            PatientPrescription appointment_One = new PatientPrescription(1, 1, 1, "", "", 0);
            PatientPrescription appointment_Two = new PatientPrescription(1, 1, 1, "", "", 0);

            PrescriptionComparer appointmentComparer = new PrescriptionComparer();

            Assert.IsTrue(appointmentComparer.Compare(appointment_One, appointment_Two) == 0);
        }

        [TestMethod]
        // Test when two prescriptions are not equal (by PrescriptionId)
        public void AppointmentComparer_NotEqual_Test() {
            PatientPrescription prescription_One = new PatientPrescription(1, 1, 1, "", "", 0);
            PatientPrescription prescription_Two = new PatientPrescription(2, 1, 2, "", "", 1);

            PrescriptionComparer prescriptionComparer = new PrescriptionComparer();

            Assert.IsTrue(prescriptionComparer.Compare(prescription_One, prescription_Two) != 0);
        }
    }
}
