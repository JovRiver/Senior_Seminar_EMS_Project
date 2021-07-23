using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_2_EMS.Models.DatabaseModels;
using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;

namespace Project_2_EMS_Tests.Models_Tests.DatabaseModels_Tests.SqlQueryModels_Tests {
    /// 
    /// Test the appointment query objects in the AppointmentQueryModels
    /// 
    [TestClass]
    public class AppointmentQuery_Tests {
        [TestMethod]
        public void CountAppointment_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            int expectedCount = 5;
            int actualCount = 0;

            CountAppointment query = new CountAppointment();
            mock_IDbAccess.Setup(c => c.ExecuteCountQuery(query)).Returns(expectedCount);

            actualCount = mock_IDbAccess.Object.ExecuteCountQuery(query);

            mock_IDbAccess.Verify(c => c.ExecuteCountQuery(query), Times.Once);

            // Verify that the count query returned the expected value
            Assert.IsTrue(expectedCount == actualCount);
        }

        [TestMethod]
        public void DeleteAppointmentBy_VisitId_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            bool success = false;

            DeleteAppointmentBy_VisitId query = new DeleteAppointmentBy_VisitId(1);
            mock_IDbAccess.Setup(n => n.ExecuteNonQuery(query)).Returns(true);

            success = mock_IDbAccess.Object.ExecuteNonQuery(query);

            mock_IDbAccess.Verify(n => n.ExecuteNonQuery(query), Times.Once);

            // Verify that the NonQuery returned a successful execution
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void InsertAppointment_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            bool success = false;

            PatientAppointment appointment = new PatientAppointment(1, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "");

            InsertAppointment query = new InsertAppointment(appointment);
            mock_IDbAccess.Setup(n => n.ExecuteNonQuery(query)).Returns(true);

            success = mock_IDbAccess.Object.ExecuteNonQuery(query);

            mock_IDbAccess.Verify(n => n.ExecuteNonQuery(query), Times.Once);

            // Verify that the NonQuery returned a successful execution
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void SelectAppointmentBy_Date_PatientId_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientAppointment> expected = new List<PatientAppointment> {
                new PatientAppointment(5, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", ""),
                new PatientAppointment(4, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "")
            };
            List<PatientAppointment> actual = new List<PatientAppointment>();

            SelectAppointmentBy_Date_PatientId<PatientAppointment> query = new SelectAppointmentBy_Date_PatientId<PatientAppointment>(DateTime.MinValue, 1);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify the appointment dates match for both appointments
            Assert.IsTrue(expected[0].ApptDate == actual[0].ApptDate);
            Assert.IsTrue(expected[0].ApptDate == actual[1].ApptDate);

            // Verify the appointment patient id's match for both
            Assert.IsTrue(expected[0].PatientId == actual[0].PatientId);
            Assert.IsTrue(expected[0].PatientId == actual[1].PatientId);

            // Verify that there are only 2 appointments, like we expect
            Assert.IsTrue(actual.Count == 2);
        }

        [TestMethod]
        public void SelectAppointmentBy_DateRange_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientAppointment> expected = new List<PatientAppointment> {
                new PatientAppointment(5, 1, DateTime.Parse("1/4/2001"), TimeSpan.MinValue, decimal.Zero, "", "", ""),
                new PatientAppointment(4, 1, DateTime.Parse("1/6/2001"), TimeSpan.MinValue, decimal.Zero, "", "", "")
            };
            List<PatientAppointment> actual = new List<PatientAppointment>();

            DateTime start = DateTime.Parse("1/1/2001");
            DateTime end = DateTime.Parse("1/10/2001");

            SelectAppointmentBy_DateRange<PatientAppointment> query = new SelectAppointmentBy_DateRange<PatientAppointment>(start, end);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify that we received the expected appointments
            Assert.IsTrue(expected[0].ApptDate ==  actual[0].ApptDate);
            Assert.IsTrue(expected[1].ApptDate == actual[1].ApptDate);

            // Verify that the dates of the two appointments fall between the start and end dates
            Assert.IsTrue(start <= actual[0].ApptDate);
            Assert.IsTrue(end >= actual[0].ApptDate);
            Assert.IsTrue(start <= actual[1].ApptDate);
            Assert.IsTrue(end >= actual[1].ApptDate);

            // Verify that there are only 2 appointments, like we expect
            Assert.IsTrue(actual.Count == 2);
        }

        [TestMethod]
        public void SelectAppointmentBy_PatientId_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientAppointment> expected = new List<PatientAppointment> {
                new PatientAppointment(5, 1, DateTime.Parse("1/4/2001"), TimeSpan.MinValue, decimal.Zero, "", "", ""),
                new PatientAppointment(4, 1, DateTime.Parse("1/6/2001"), TimeSpan.MinValue, decimal.Zero, "", "", "")
            };
            List<PatientAppointment> actual = new List<PatientAppointment>();

            SelectAppointmentBy_PatientId<PatientAppointment> query = new SelectAppointmentBy_PatientId<PatientAppointment>(1);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify that we received the expected appointments by PatientId
            Assert.IsTrue(expected[0].PatientId == actual[0].PatientId);
            Assert.IsTrue(expected[0].PatientId == actual[1].PatientId);

            // Verify that there are only 2 appointments, like we expect
            Assert.IsTrue(actual.Count == 2);
        }

        [TestMethod]
        public void SelectAppointmentBy_VisitId_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientAppointment> expected = new List<PatientAppointment> {
                new PatientAppointment(4, 1, DateTime.Parse("1/4/2001"), TimeSpan.MinValue, decimal.Zero, "", "", "")
            };
            List<PatientAppointment> actual = new List<PatientAppointment>();

            SelectAppointmentBy_VisitId<PatientAppointment> query = new SelectAppointmentBy_VisitId<PatientAppointment>(4);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);

            // Verify that we received the expected appointment by VisitId
            Assert.IsTrue(expected[0].VisitId == actual[0].VisitId);

            // Verify that there is only 1 appointment, like we expect
            Assert.IsTrue(actual.Count == 1);
        }
    }
}
