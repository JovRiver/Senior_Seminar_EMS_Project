using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlSelectQuery : ISqlTypeQuery {
        public void ExecuteDatabaseQuery(ISqlTableQuery tableQuery, SqlCommand command, ListManager listManager) => tableQuery.Read(command, listManager);

        public string GetQueryString(ISqlTableQuery tableQuery, string queryBy) => tableQuery.Select(queryBy);
    }
}
