using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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

            Assert.IsTrue(connectionOpenSuccess && connectionCloseSuccess);
        }

        [TestMethod]
        public void DatabaseCountQuery_Test() {

        }

        [TestMethod]
        public void DatabaseListQuery_Test() {

        }

        [TestMethod]
        public void DatabaseNonQuery_Test() {

        }
    }
}
