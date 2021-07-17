using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlUpdateQuery : ISqlTypeQuery {
        public void ExecuteDatabaseQuery(ISqlTableQuery tableQuery, SqlCommand command, ListManager listManager) {
            _ = command.ExecuteNonQuery();
        }

        public string GetQueryString(ISqlTableQuery tableQuery, string queryBy) => tableQuery.Update(queryBy);
    }
}
