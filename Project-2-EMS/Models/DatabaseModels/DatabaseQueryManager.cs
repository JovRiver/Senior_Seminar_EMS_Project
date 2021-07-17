using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager {
        private readonly ListManager ListManager;
        
        public List<PatientAppointment> QueryAppointments(SqlCommandParameters parameters, SqlQueryManager queryManager) {
            ExecuteQuery(parameters, queryManager);
            return ListManager.AppointmentList;
        }

        public List<Patient> QueryPatients(SqlCommandParameters parameters, SqlQueryManager queryManager) {
            ExecuteQuery(parameters, queryManager);
            return ListManager.PatientList;
        }

        public List<PatientPrescription> QueryPrescriptions(SqlCommandParameters parameters, SqlQueryManager queryManager) {
            ExecuteQuery(parameters, queryManager);
            return ListManager.PrescriptionList;
        }

        private void ExecuteQuery(SqlCommandParameters parameters, SqlQueryManager queryManager) {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MDR_ConnStr"].ConnectionString)) {
                using (SqlCommand command = new SqlCommandManager().CreateCommandWithParameters(parameters, connection, queryManager)) {
                    try {
                        connection.Open();

                        queryManager.ExecuteQuery(command, ListManager);
                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error Executing Database Query:\n{e}");
                    }
                }
            }
        }
    }
}
