using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_2_EMS.Models.DatabaseModels;
using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS_Tests.Models_Tests.DatabaseModels_Tests {
    
    /// <summary>
    /// Test that SqlDatabaseAccess performs as expected
    /// </summary>

    [TestClass]
    public class SqlDatabaseAccess_Test {
        [TestMethod]
        public void DatabaseConnection_Test() {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|App_Data\EMR_DB.mdf; Integrated Security=True");
            bool connectionOpenSuccess = false;
            bool connectionCloseSuccess = false;

            try {
                connection.Open();
                connectionOpenSuccess = connection.State == ConnectionState.Open;

                connection.Close();
                connectionCloseSuccess = connection.State == ConnectionState.Closed;
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

            Mock<ICountCommand> query = new Mock<ICountCommand>();
            mock_IDbAccess.Setup(c => c.ExecuteCountQuery(query.Object)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteCountQuery(query.Object);

            mock_IDbAccess.Verify(c => c.ExecuteCountQuery(query.Object), Times.Once);
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

            Mock<ISelectCommand<PatientAppointment>> query = new Mock<ISelectCommand<PatientAppointment>>();
            mock_IDbAccess.Setup(l => l.ExecuteListQuery(query.Object)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteListQuery(query.Object);

            mock_IDbAccess.Verify(l => l.ExecuteListQuery(query.Object), Times.Once);
            Assert.IsTrue(expected[0].VisitId == actual[0].VisitId);
            Assert.IsFalse(expected[1].VisitId == actual[0].VisitId);
        }

        [TestMethod]
        public void DatabaseNonQuery_Test() {
            Mock<ISqlDatabaseAccess> mock_IDbAccess = new Mock<ISqlDatabaseAccess>();
            bool expected = true;
            bool actual = false;

            Mock<INonQueryCommand> query = new Mock<INonQueryCommand>();
            mock_IDbAccess.Setup(n => n.ExecuteNonQuery(query.Object)).Returns(expected);

            actual = mock_IDbAccess.Object.ExecuteNonQuery(query.Object);

            mock_IDbAccess.Verify(n => n.ExecuteNonQuery(query.Object), Times.Once);
            Assert.IsTrue(expected && actual);
        }
    }
}
