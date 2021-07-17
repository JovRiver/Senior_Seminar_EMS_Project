namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlTypeQuery {
        void ExecuteDatabaseQuery();
        string GetQueryString(ISqlTableQuery tableQuery, string queryBy);
    }
}
