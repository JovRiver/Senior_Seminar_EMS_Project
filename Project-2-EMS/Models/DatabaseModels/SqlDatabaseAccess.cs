using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlDatabaseAccess : ISqlDatabaseAccess {
        private const string _ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|App_Data\EMR_DB.mdf; Integrated Security=True";

        public int ExecuteCountQuery(ICountQuery query) {
            try {
                using (SqlConnection connection = new SqlConnection(_ConnectionString)) {
                    using (SqlCommand command = new SqlCommand()) {
                        connection.Open();
                        return query.ExecuteQuery(connection, command);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine($"Error Executing Count Query:\n{e}");
                return -1;
            }
        }

        public List<T> ExecuteListQuery<T>(IListQuery<T> query) where T: IPatient {
            try {
                using (SqlConnection connection = new SqlConnection(_ConnectionString)) {
                    using (SqlCommand command = new SqlCommand()) {
                        connection.Open();
                        return query.ExecuteQuery(connection, command);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine($"Error Executing List Query:\n{e}");
                return new List<T>();
            }
        }

        public bool ExecuteNonQuery(INonQuery query) {
            try {
                using (SqlConnection connection = new SqlConnection(_ConnectionString)) {
                    using (SqlCommand command = new SqlCommand()) {
                        connection.Open();
                        query.ExecuteQuery(connection, command);
                        return true;
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine($"Error Executing NonQuery:\n{e}");
                return false;
            }
        }
    }
}
