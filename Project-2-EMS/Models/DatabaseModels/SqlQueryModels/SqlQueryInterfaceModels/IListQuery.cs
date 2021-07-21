using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface IListQuery<T> {
        List<T> ExecuteQuery(SqlConnection connection, SqlCommand command);
    }
}
