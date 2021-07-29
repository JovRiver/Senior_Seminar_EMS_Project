using System;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlNonQueryReader : ISqlReader {
        public T Read<T>(SqlCommand command) {
            _ = command.ExecuteNonQuery();
            return (T)Convert.ChangeType(true, typeof(T));
        }
    }
}
