using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlTypeQuery {
        void ExecuteDatabaseQuery(ISqlTableQuery tableQuery, SqlCommand command, ListManager listManager);
        string GetQueryString(ISqlTableQuery tableQuery, string queryBy);
    }
}
