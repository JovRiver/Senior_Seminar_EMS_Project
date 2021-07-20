using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_2_EMS.Models.ComparerModels;
using Project_2_EMS.Models.DatabaseModels;
using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS_Tests.Models_Tests.DatabaseModels_Tests {
    /// 
    /// Test each of the methods for the DatabaseQueryManager class
    /// 
    [TestClass]
    public class DatabaseQueryManager_Test {
        [TestMethod]
        // Test that we can successfully connect to the database
        public void DatabaseConnection_Open_Test() {
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

            Assert.IsTrue(connectionOpenSuccess && connectionCloseSuccess);
        }

        [TestMethod]
        // Test a mock query to the database to check if the returned appointment and dummy appointment are equal
        public void AppointmentQuery_Equal_Test() {
            Mock<DatabaseQueryManager> mock_DbManager = new Mock<DatabaseQueryManager>();
            List<PatientAppointment> list = mock_DbManager.Object.AppointmentQuery(new SelectAppointmentBy_VisitId(1));

            PatientAppointment appointment = new PatientAppointment(1, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "");

            AppointmentComparer comparer = new AppointmentComparer();

            Assert.IsTrue(comparer.Compare(appointment, list[0]) == 0);
        }

        [TestMethod]
        // Test a mock query to the database to check if the returned appointment and dummy appointment are not equal
        public void AppointmentQuery_NotEqual_Test() {
            Mock<DatabaseQueryManager> mock_DbManager = new Mock<DatabaseQueryManager>();
            List<PatientAppointment> list = mock_DbManager.Object.AppointmentQuery(new SelectAppointmentBy_VisitId(1));

            PatientAppointment appointment = new PatientAppointment(2, 1, DateTime.MinValue, TimeSpan.MinValue, decimal.Zero, "", "", "");

            AppointmentComparer comparer = new AppointmentComparer();

            Assert.IsTrue(comparer.Compare(appointment, list[0]) != 0);
        }
    }
}
