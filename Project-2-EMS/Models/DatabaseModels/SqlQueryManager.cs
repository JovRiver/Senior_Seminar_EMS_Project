namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlQueryManager {
        public string QueryTable { get; }
        public string QueryBy { get; }
        public string QueryType { get; }

        public SqlQueryManager(string queryTable, string queryBy, string queryType) {
            QueryTable = queryTable;
            QueryBy = queryBy;
            QueryType = queryType;
        }
    }
}
