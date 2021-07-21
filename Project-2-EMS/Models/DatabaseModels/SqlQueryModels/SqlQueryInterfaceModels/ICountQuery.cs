using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ICountQuery {
        int ExecuteQuery(SqlConnection connection, SqlCommand command);
    }
}
