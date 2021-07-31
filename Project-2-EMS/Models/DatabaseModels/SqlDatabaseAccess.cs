using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlDatabaseAccess : ISqlDatabaseAccess {
        private const string _ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|App_Data\EMR_DB.mdf; Integrated Security=True";

        public int ExecuteCountQuery(ICountCommand queryCommand) {
            int count = Execute<int>(queryCommand, new SqlCountReader());
            return count > 0 ? count : -1;
        }

        public List<T> ExecuteListQuery<T>(ISelectCommand<T> queryCommand) where T : IPatient {
            return Execute<List<T>>(queryCommand, new SqlListReader()) ?? new List<T>();
        }

        public bool ExecuteNonQuery(INonQueryCommand queryCommand) {
            return Execute<bool>(queryCommand, new SqlNonQueryReader());
        }

        private T Execute<T>(ISqlQueryCommand queryCommand, ISqlReader reader) {
            try {
                using (SqlConnection connection = new SqlConnection(_ConnectionString)) {
                    using (SqlCommand command = queryCommand.ConnectSqlCommand(connection)) {
                        connection.Open();
                        return (T)Convert.ChangeType(reader.Read<T>(command), typeof(T));
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine($"Error Executing NonQuery:\n{e}");
                return default;
            }
        }
    }
}
