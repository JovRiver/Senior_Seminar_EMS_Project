using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager {
        private readonly ISqlTypeQuery TypeQuery;
        private readonly ISqlTableQuery TableQuery;
        private readonly SqlCommandParameters Parameters;
        private readonly string QueryBy;

        private readonly ListManager ListManager = new ListManager();

        public DatabaseQueryManager(SqlCommandParameters parameters, ISqlTypeQuery typeQuery, ISqlTableQuery tableQuery, string queryBy) {
            TypeQuery = typeQuery;
            TableQuery = tableQuery;
            Parameters = parameters;
            QueryBy = queryBy;
        }

        public List<PatientAppointment> QueryAppointments() {
            ExecuteQuery();
            return ListManager.AppointmentList;
        }

        public List<Patient> QueryPatients() {
            ExecuteQuery();
            return ListManager.PatientList;
        }

        public List<PatientPrescription> QueryPrescriptions() {
            ExecuteQuery();
            return ListManager.PrescriptionList;
        }

        private string GetQueryString() => TypeQuery.GetQueryString(TableQuery, QueryBy);

        private void ExecuteQuery() {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MDR_ConnStr"].ConnectionString)) {
                using (SqlCommand command = new SqlCommandManager().CreateCommandWithParameters(GetQueryString(), connection, Parameters)) {
                    
                    
                    
                    try {
                        connection.Open();
                        TypeQuery.ExecuteDatabaseQuery(TableQuery, command, ListManager);
                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error Executing Database Query:\n{e}");
                    }
                }
            }
        }
    }
}
