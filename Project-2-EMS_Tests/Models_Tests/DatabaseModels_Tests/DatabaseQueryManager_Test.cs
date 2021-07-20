using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        private readonly Mock<DatabaseQueryManager> Mock_DbManager = new Mock<DatabaseQueryManager>();

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
        // Test a mock query to the database to check if it returns an appointment list
        public void AppointmentQuery_Test() {
            SelectAppointmentBy_VisitId query = new SelectAppointmentBy_VisitId(1);
            List<PatientAppointment> list = Mock_DbManager.Object.AppointmentQuery(query);

            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        // Test a mock query to the database to check if it returns a count
        public void CountQuery_Test() {
            CountAppointment query = new CountAppointment();
            int count = Mock_DbManager.Object.CountQuery(query);

            Assert.IsTrue(count != -1);
        }

        [TestMethod]
        // Test a mock query to the database to check if it successfully executes a nonquery
        public void NonReturnQuery_Test() {
            UpdateBalanceBy_Cost_PatientId query = new UpdateBalanceBy_Cost_PatientId(0, 1);
            Assert.IsTrue(Mock_DbManager.Object.NonReturnQuery(query));
        }

        [TestMethod]
        // Test a mock query to the database to check if it returns a patientinfo list
        public void PatientInfoQuery_Test() {
            SelectPatientInfoBy_PatientId query = new SelectPatientInfoBy_PatientId(1);
            List<PatientInfo> list = Mock_DbManager.Object.PatientInfoQuery(query);

            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        // Test a mock query to the database to check if it returns a prescription list
        public void PrescriptionQuery_Test() {
            SelectPrescriptionBy_PatientId query = new SelectPrescriptionBy_PatientId(1);
            List<PatientPrescription> list = Mock_DbManager.Object.PrescriptionQuery(query);

            Assert.IsTrue(list.Count > 0);
        }
    }
}
