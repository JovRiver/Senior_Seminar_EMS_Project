using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_2_EMS.Models.DatabaseModels;
using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Project_2_EMS_Tests.Models_Tests.DatabaseModels_Tests.SqlQueryModels_Tests {
    /// 
    /// Test the SqlListReader and SqlCountReader classes
    /// 
    [TestClass]
    public class SqlReader_Tests {
        [TestMethod]
        public void SqlCountReader_Test() {
            Mock<ISqlCountReader> mock_reader = new Mock<ISqlCountReader>();
            int expected = 5;
            int actual = 0;

            SqlCommand command = new SqlCommand();

            mock_reader.Setup(r => r.Read(command)).Returns(expected);

            actual = mock_reader.Object.Read(command);

            mock_reader.Verify(r => r.Read(command), Times.Once);

            // Assert that the actual list is pointing to the expected return list
            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void SqlListReader_PatientAppointment_Test() {
            Mock<ISqlListReader<PatientAppointment>> mock_reader = new Mock<ISqlListReader<PatientAppointment>>();
            List<PatientAppointment> expected = new List<PatientAppointment>();
            List<PatientAppointment> actual = new List<PatientAppointment>();

            SqlCommand command = new SqlCommand();

            mock_reader.Setup(r => r.Read(command)).Returns(expected);

            actual = mock_reader.Object.Read(command);

            mock_reader.Verify(r => r.Read(command), Times.Once);

            // Assert that the actual list is pointing to the expected return list
            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void SqlListReader_PatientInfo_Test() {
            Mock<ISqlListReader<PatientInfo>> mock_reader = new Mock<ISqlListReader<PatientInfo>>();
            List<PatientInfo> expected = new List<PatientInfo>();
            List<PatientInfo> actual = new List<PatientInfo>();

            SqlCommand command = new SqlCommand();

            mock_reader.Setup(r => r.Read(command)).Returns(expected);

            actual = mock_reader.Object.Read(command);

            mock_reader.Verify(r => r.Read(command), Times.Once);

            // Assert that the actual list is pointing to the expected return list
            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void SqlListReader_PatientPrescription_Test() {
            Mock<ISqlListReader<PatientPrescription>> mock_reader = new Mock<ISqlListReader<PatientPrescription>>();
            List<PatientPrescription> expected = new List<PatientPrescription>();
            List<PatientPrescription> actual = new List<PatientPrescription>();

            SqlCommand command = new SqlCommand();

            mock_reader.Setup(r => r.Read(command)).Returns(expected);

            actual = mock_reader.Object.Read(command);

            mock_reader.Verify(r => r.Read(command), Times.Once);

            // Assert that the actual list is pointing to the expected return list
            Assert.IsTrue(actual == expected);
        }
    }
}
