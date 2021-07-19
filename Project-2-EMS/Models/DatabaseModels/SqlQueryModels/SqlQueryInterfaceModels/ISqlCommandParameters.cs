using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    interface ISqlCommandParameters : ISqlQuery {
        void AddParameters(SqlCommand command);
    }
}
