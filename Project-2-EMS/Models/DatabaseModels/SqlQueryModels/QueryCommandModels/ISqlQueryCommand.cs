using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlQueryCommand {
        SqlCommand ConnectSqlCommand(SqlConnection connection);
    }
}
