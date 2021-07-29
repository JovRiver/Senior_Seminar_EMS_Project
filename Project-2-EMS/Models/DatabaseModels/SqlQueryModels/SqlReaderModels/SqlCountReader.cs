using System;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCountReader : ISqlReader {
        public T Read<T>(SqlCommand command) {
            int count = -1;
            using (SqlDataReader dataReader = command.ExecuteReader()) {
                while (dataReader.Read()) {
                    count = dataReader.GetInt32(0);
                }
            }
            return (T)Convert.ChangeType(count, typeof(T));
        }
    }
}
