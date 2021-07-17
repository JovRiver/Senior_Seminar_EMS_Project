namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlUpdateQuery : ISqlTypeQuery {
        public void ExecuteDatabaseQuery() {
            throw new System.NotImplementedException();
        }

        public string GetQueryString(ISqlTableQuery tableQuery, string queryBy) => tableQuery.Update(queryBy);
    }
}
