using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager {
        private readonly DatabaseConnectionManager dbConnMan = new DatabaseConnectionManager();

        public DatabaseQueryListManager MakeQuery(String queryBy, String queryType, String listType) {
            DatabaseQueryListManager listManager;

            switch (listType.ToLower()) {
                case "patientappointment":
                    listManager = new DatabaseQueryListManager(appointments: new List<PatientAppointment>());
                    break;
                case "patient":
                    listManager = new DatabaseQueryListManager(patients: new List<Patient>());
                    break;
                case "patientprescription":
                    listManager = new DatabaseQueryListManager(prescriptions: new List<PatientPrescription>());
                    break;
                default: 
                    listManager = new DatabaseQueryListManager();
                    break;
            }

            ExecuteQuery(queryBy, queryType, listManager);
            return listManager;
        }

        private void ExecuteQuery(String queryBy, String queryType, DatabaseQueryListManager queryList) {
            using (SqlConnection connection = dbConnMan.ConnectToDatabase()) {
                using (SqlCommand command = AppointmentSQLCommands(queryBy)) {
                    try {
                        switch (queryType.ToLower()) {
                            case "delete":
                                _ = command.ExecuteNonQuery();
                                break;
                            case "query":

                                break;
                            case "update":
                                _ = command.ExecuteNonQuery();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error Executing SQL Statements:\n{e}");
                    }
                }
            }
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
