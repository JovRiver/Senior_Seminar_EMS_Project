using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlPatientInfoQuery : ISqlTableQuery {
        public string Delete(string queryBy) => new SqlPatientInfoStrings(queryBy).DeleteString();

        public string Insert() => new SqlPatientInfoStrings(string.Empty).InsertString();

        public string Select(string queryBy) => new SqlPatientInfoStrings(queryBy).SelectString();

        public string Update(string queryBy) => new SqlPatientInfoStrings(queryBy).UpdateString();

        public void Read(SqlCommand command, ListManager listManager) => new SqlCommandPatientInfoReader().Read(command, listManager);
    }
}
