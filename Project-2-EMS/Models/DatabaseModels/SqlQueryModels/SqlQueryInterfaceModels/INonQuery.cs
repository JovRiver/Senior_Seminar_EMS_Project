﻿using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface INonQuery {
        void ExecuteQuery(SqlConnection connection, SqlCommand command);
    }
}
