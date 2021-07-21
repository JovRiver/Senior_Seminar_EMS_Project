using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface IListQuery {
        List<T> ExecuteQuery<T>(SqlConnection connection, SqlCommand command);
    }
}
