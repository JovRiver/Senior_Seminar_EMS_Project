using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCountReader {
        public int Read(SqlCommand command) {
            int count = -1;
            using (SqlDataReader dataReader = command.ExecuteReader()) {
                while (dataReader.Read()) {
                    count = dataReader.GetInt32(0);
                }
            }
            return count;
        }
    }
}
