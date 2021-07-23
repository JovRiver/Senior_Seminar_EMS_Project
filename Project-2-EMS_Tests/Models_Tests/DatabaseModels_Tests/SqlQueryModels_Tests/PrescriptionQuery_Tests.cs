using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_2_EMS.Models.DatabaseModels;
using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_2_EMS_Tests.Models_Tests.DatabaseModels_Tests.SqlQueryModels_Tests {
    /// 
    /// Test the appointment query objects in the PrescriptionQueryModels
    /// 
    [TestClass]
    public class PrescriptionQuery_Tests {
        [TestMethod]
        public void CountPrescription_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            int expectedCount = 5;
            int actualCount = 0;

            CountPrescription query = new CountPrescription();
            mock_IDbAccess.Setup(c => c.ExecuteCountQuery(query)).Returns(expectedCount);

            actualCount = mock_IDbAccess.Object.ExecuteCountQuery(query);

            mock_IDbAccess.Verify(c => c.ExecuteCountQuery(query), Times.Once);

            // Verify that the count query returned the expected value
            Assert.IsTrue(expectedCount == actualCount);
        }

        [TestMethod]
        public void InsertPrescription_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            bool success = false;

            PatientPrescription prescription = new PatientPrescription(1, 1, 4, "", "", 2);

            InsertPrescription query = new InsertPrescription(prescription);
            mock_IDbAccess.Setup(n => n.ExecuteNonQuery(query)).Returns(true);

            success = mock_IDbAccess.Object.ExecuteNonQuery(query);

            mock_IDbAccess.Verify(n => n.ExecuteNonQuery(query), Times.Once);

            // Verify that the NonQuery returned a successful execution
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void SelectPrescriptionBy_PatientId_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientPrescription> expected = new List<PatientPrescription> {
                new PatientPrescription(1, 2, 4, "", "", 2)
            };
            List<PatientPrescription> actual = new List<PatientPrescription>();

            int patientId = 2;

            SelectPrescriptionBy_PatientId<PatientPrescription> query = new SelectPrescriptionBy_PatientId<PatientPrescription>(patientId);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify that we received the expected prescription by PatientId
            Assert.IsTrue(actual[0].PatientId == patientId);

            // Verify that there is only 1 prescription, like we expect
            Assert.IsTrue(actual.Count == 1);
        }

        [TestMethod]
        public void SelectPrescriptionBy_VisitId_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientPrescription> expected = new List<PatientPrescription> {
                new PatientPrescription(1, 2, 4, "", "", 2)
            };
            List<PatientPrescription> actual = new List<PatientPrescription>();

            int visitId = 4;

            SelectPrescriptionBy_PatientId<PatientPrescription> query = new SelectPrescriptionBy_PatientId<PatientPrescription>(visitId);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify that we received the expected prescription by VisitId
            Assert.IsTrue(actual[0].VisitId == visitId);

            // Verify that there is only 1 prescription, like we expect
            Assert.IsTrue(actual.Count == 1);
        }
    }
}
