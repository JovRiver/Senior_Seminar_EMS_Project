using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCountReader : ISqlReader {
        public int Count { get; set; } = -1;

        public void Read(SqlCommand command) {
            using (SqlDataReader dataReader = command.ExecuteReader()) {
                while (dataReader.Read()) {
                    Count = dataReader.GetInt32(0);
                }
            }
        }
    }
}
