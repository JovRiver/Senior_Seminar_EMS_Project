using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlQueryManager {
        private readonly ISqlTypeQuery TypeQuery;
        private readonly ISqlTableQuery TableQuery;
        private readonly string QueryBy;

        public SqlQueryManager(ISqlTypeQuery typeQuery, ISqlTableQuery tableQuery, string queryBy) {
            TypeQuery = typeQuery;
            TableQuery = tableQuery;
            QueryBy = queryBy;
        }

        public string GetQueryString() => TypeQuery.GetQueryString(TableQuery, QueryBy);

        public void ExecuteQuery(SqlCommand command) {

        }
    }
}
