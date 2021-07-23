using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlListReader<T> {
        List<T> Read(SqlCommand command);
    }
}
