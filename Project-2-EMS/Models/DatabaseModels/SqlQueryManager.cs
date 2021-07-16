namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlQueryManager {
        public string QueryTable { get; }
        public string QueryBy { get; }
        public string QueryType { get; }

        public string QueryString { get; set; }

        public SqlQueryManager(string queryTable, string queryType, string queryBy) {
            QueryTable = queryTable;
            QueryBy = queryBy;
            QueryType = queryType;
        }

        public void FillQueryString(string queryString) {
            QueryString = queryString;
        }
    }
}
