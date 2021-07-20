using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_2_EMS.Models.ComparerModels;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS_Tests.Models_Tests.ComparerModels_Tests {
    /// 
    /// Test that the PatientInfoComparer correctly compares two patients
    /// 
    [TestClass]
    public class PatientInfoComparer_Test {
        [TestMethod]
        // Test when two patients are equal (by PatientId)
        public void AppointmentComparer_Equal_Test() {
            PatientInfo patient_One = new PatientInfo(1, "", "");
            PatientInfo patient_Two = new PatientInfo(1, "", "");

            PatientInfoComparer patientInfoComparer = new PatientInfoComparer();

            Assert.IsTrue(patientInfoComparer.Compare(patient_One, patient_Two) == 0);
        }

        [TestMethod]
        // Test when two patients are not equal (by PatientId)
        public void AppointmentComparer_NotEqual_Test() {
            PatientInfo patient_One = new PatientInfo(1, "", "");
            PatientInfo patient_Two = new PatientInfo(2, "", "");

            PatientInfoComparer patientInfoComparer = new PatientInfoComparer();

            Assert.IsTrue(patientInfoComparer.Compare(patient_One, patient_Two) != 0);
        }
    }
}
