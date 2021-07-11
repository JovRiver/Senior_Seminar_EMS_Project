using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager {
        private readonly DatabaseConnectionManager dbConnMan = new DatabaseConnectionManager();

        public List<PatientAppointment> AppointmentQuery(String queryBy) {
            List<PatientAppointment> appointments = new List<PatientAppointment>();

            using (SqlConnection connection = dbConnMan.ConnectToDatabase()) {
                using (SqlCommand command = AppointmentSQLCommands(queryBy)) {
                    try {

                    }
                    catch (Exception e) { }
                }
            }

            return appointments;
        }

        public List<Patient> PatientInfoQuery(String queryBy) {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection connection = dbConnMan.ConnectToDatabase()) {
                using (SqlCommand command = PatientInfoSQLCommands(queryBy)) {
                    try {

                    }
                    catch (Exception e) { }
                }
            }

            return patients;
        }

        public List<PatientPrescription> PrescriptionQuery(String queryBy) {
            List<PatientPrescription> prescriptions = new List<PatientPrescription>();

            using (SqlConnection connection = dbConnMan.ConnectToDatabase()) {
                using (SqlCommand command = PrescriptionSQLCommands(queryBy)) {
                    try {

                    }
                    catch (Exception e) { }
                }
            }

            return prescriptions;
        }

        private SqlCommand AppointmentSQLCommands(String queryBy) {
            SqlCommand command = new SqlCommand();

            switch (queryBy) {

            }

            return command;
        }

        private SqlCommand PatientInfoSQLCommands(String queryBy) {
            SqlCommand command = new SqlCommand();

            switch (queryBy) {

            }

            return command;
        }

        private SqlCommand PrescriptionSQLCommands(String queryBy) {
            SqlCommand command = new SqlCommand();

            switch (queryBy) {

            }

            return command;
        }
    }
}
