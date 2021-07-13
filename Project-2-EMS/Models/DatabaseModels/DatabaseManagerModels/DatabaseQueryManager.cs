using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager : DatabaseConnectionManager {

        public DatabaseQueryListManager MakeQuery(SqlCommandParameters parameters, String queryTable, String queryBy, String queryType, String listType) {
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

            ExecuteQuery(parameters, queryTable, queryBy, queryType, listManager);
            return listManager;
        }

        private void ExecuteQuery(SqlCommandParameters parameters, String queryTable, String queryBy, String queryType, DatabaseQueryListManager listType) {
            using (SqlConnection connection = ConnectToDatabase()) {
                SqlCommandManager commandManager = new SqlCommandManager();
                using (SqlCommand command = commandManager.CreateCommandWithParameters(parameters, queryTable, queryBy, connection)) {
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
    }
}
