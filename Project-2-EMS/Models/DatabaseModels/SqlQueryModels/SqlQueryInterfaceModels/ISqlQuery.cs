using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlQuery {
        SqlCommand ConnectSqlCommand(SqlConnection connection);
    }
}
