using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlNoReturnReader : ISqlReader {
        public void Read(SqlCommand command) {
            _ = command.ExecuteNonQuery();
        }
    }
}
