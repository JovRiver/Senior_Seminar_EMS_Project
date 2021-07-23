using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_2_EMS.Models.DatabaseModels;
using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS_Tests.Models_Tests.DatabaseModels_Tests.SqlQueryModels_Tests {
    /// 
    /// Test the appointment query objects in the PatientInfoQueryModels
    /// 
    [TestClass]
    public class PatientInfoQuery_Tests {
        [TestMethod]
        public void CountPatientInfo_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            int expectedCount = 5;
            int actualCount = 0;

            CountPatientInfo query = new CountPatientInfo();
            mock_IDbAccess.Setup(c => c.ExecuteCountQuery(query)).Returns(expectedCount);

            actualCount = mock_IDbAccess.Object.ExecuteCountQuery(query);

            mock_IDbAccess.Verify(c => c.ExecuteCountQuery(query), Times.Once);

            // Verify that the count query returned the expected value
            Assert.IsTrue(expectedCount == actualCount);
        }

        [TestMethod]
        public void InsertPatientInfo_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            bool success = false;

            PatientInfo patient = new PatientInfo(1, "", "");

            InsertPatientInfo query = new InsertPatientInfo(patient);
            mock_IDbAccess.Setup(n => n.ExecuteNonQuery(query)).Returns(true);

            success = mock_IDbAccess.Object.ExecuteNonQuery(query);

            mock_IDbAccess.Verify(n => n.ExecuteNonQuery(query), Times.Once);

            // Verify that the NonQuery returned a successful execution
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void SelectPatientInfoBy_FullName_AND_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientInfo> expected = new List<PatientInfo> {
                new PatientInfo(1, "Ila", "Sia")
            };
            List<PatientInfo> actual = new List<PatientInfo>();

            string firstName = "Ila";
            string lastName = "Sia";

            SelectPatientInfoBy_FullName_AND<PatientInfo> query = new SelectPatientInfoBy_FullName_AND<PatientInfo>(firstName, lastName);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify that we received the expected patient by FullName
            Assert.IsTrue(actual[0].FirstName == firstName && actual[0].LastName == lastName);

            // Verify that there is only 1 patient, like we expect
            Assert.IsTrue(actual.Count == 1);
        }

        [TestMethod]
        public void SelectPatientInfoBy_FullName_OR_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientInfo> expected = new List<PatientInfo> {
                new PatientInfo(1, "Ila", "Lia")
            };
            List<PatientInfo> actual = new List<PatientInfo>();

            string firstName = "Ila";
            string lastName = "Sia";

            SelectPatientInfoBy_FullName_AND<PatientInfo> query = new SelectPatientInfoBy_FullName_AND<PatientInfo>(firstName, lastName);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify that we received the expected patient by FullName
            Assert.IsTrue(actual[0].FirstName == firstName || actual[0].LastName == lastName);

            // Verify that there is only 1 patient, like we expect
            Assert.IsTrue(actual.Count == 1);
        }

        [TestMethod]
        public void SelectPatientInfoBy_PatientId_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientInfo> expected = new List<PatientInfo> {
                new PatientInfo(1, "Ila", "Lia")
            };
            List<PatientInfo> actual = new List<PatientInfo>();

            int patientId = 1;

            SelectPatientInfoBy_PatientId<PatientInfo> query = new SelectPatientInfoBy_PatientId<PatientInfo>(patientId);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify that we received the expected patient by FullName
            Assert.IsTrue(actual[0].PatientId == patientId);

            // Verify that there is only 1 patient, like we expect
            Assert.IsTrue(actual.Count == 1);
        }

        [TestMethod]
        public void UpdateBalanceBy_Cost_PatientId_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            bool success = false;

            int cost = 50;
            int patientId = 1;

            UpdateBalanceBy_Cost_PatientId query = new UpdateBalanceBy_Cost_PatientId(cost, patientId);
            mock_IDbAccess.Setup(n => n.ExecuteNonQuery(query)).Returns(true);

            success = mock_IDbAccess.Object.ExecuteNonQuery(query);

            mock_IDbAccess.Verify(n => n.ExecuteNonQuery(query), Times.Once);

            // Verify that the NonQuery returned a successful execution
            Assert.IsTrue(success);
        }
    }
}
