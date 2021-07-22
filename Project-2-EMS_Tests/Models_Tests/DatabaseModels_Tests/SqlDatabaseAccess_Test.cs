using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_2_EMS.Models.DatabaseModels;
using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS_Tests.Models_Tests.DatabaseModels_Tests {
    /// 
    /// Test the SqlDatabaseAccess class which handles querying the database
    /// 
    [TestClass]
    public class SqlDatabaseAccess_Test {
        [TestMethod]
        public void DatabaseConnection_Test() {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|App_Data\EMR_DB.mdf; Integrated Security=True");
            bool connectionOpenSuccess = false;
            bool connectionCloseSuccess = false;

            try {
                connection.Open();
                connectionOpenSuccess = connection.State == System.Data.ConnectionState.Open;

                connection.Close();
                connectionCloseSuccess = connection.State == System.Data.ConnectionState.Closed;
            }
            catch (Exception e) {
                Assert.Fail(e.Message);
            }

            Assert.IsTrue(connectionOpenSuccess);
            Assert.IsTrue(connectionCloseSuccess);
        }

        [TestMethod]
        public void DatabaseCountQuery_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            int expected = 5;
            int actual = 0;
            
            CountAppointment query = new CountAppointment();
            mock_IDbAccess.Setup(c => c.ExecuteCountQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteCountQuery(query);

            mock_IDbAccess.Verify(c => c.ExecuteCountQuery(query), Times.Once);
            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void DatabaseListQuery_Equal_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            List<PatientAppointment> expected = new List<PatientAppointment> {
                new PatientAppointment(5, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", ""),
                new PatientAppointment(4, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "")
            };
            List<PatientAppointment> actual = new List<PatientAppointment>();

            SelectAppointmentBy_PatientId<PatientAppointment> query = new SelectAppointmentBy_PatientId<PatientAppointment>(1);
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query), Times.Once);
            Assert.IsTrue(expected[0].VisitId == actual[0].VisitId);
            Assert.IsFalse(expected[1].VisitId == actual[0].VisitId);
            Assert.IsTrue(actual.Count == 2);
        }

        [TestMethod]
        public void DatabaseNonQuery_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            bool expected = true;
            bool actual = false;

            UpdateBalanceBy_Cost_PatientId query = new UpdateBalanceBy_Cost_PatientId(50, 1);
            mock_IDbAccess.Setup(n => n.ExecuteNonQuery(query)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteNonQuery(query);

            mock_IDbAccess.Verify(n => n.ExecuteNonQuery(query), Times.Once);
            Assert.IsTrue(expected && actual);
        }
    }
}
