using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace Project_2_EMS_Tests.Models_Tests.DatabaseModels_Tests {
    /// 
    /// Test each of the methods for the DatabaseQueryManager class
    /// 
    [TestClass]
    public class DatabaseQueryManager_Test {
        [TestMethod]
        public void DatabaseConnection_Open_Test() {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|App_Data\EMR_DB.mdf; Integrated Security=True");
            bool isConnected = false;
            bool isClosed = false;

            try {
                connection.Open();
                isConnected = connection.State == System.Data.ConnectionState.Open;

                connection.Close();
                isClosed = connection.State == System.Data.ConnectionState.Closed;
            }
            catch (Exception e) {
                Assert.Fail(e.Message);
            }

            Assert.IsTrue(isConnected && isClosed);
        }
    }
}
