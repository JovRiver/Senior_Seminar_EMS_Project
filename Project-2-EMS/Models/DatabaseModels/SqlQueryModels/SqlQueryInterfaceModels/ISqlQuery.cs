using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlQuery {
        void ExecuteQuery(SqlCommand command, ISqlReader sqlReader);
        string GetQueryString();
    }
}
