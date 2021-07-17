using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlPrescriptionQuery : ISqlTableQuery {
        public string Delete(string queryBy) => new SqlPrescriptionStrings(queryBy).DeleteString();

        public string Insert() => new SqlPrescriptionStrings(string.Empty).InsertString();

        public string Select(string queryBy) => new SqlPrescriptionStrings(queryBy).SelectString();

        public string Update(string queryBy) => new SqlPrescriptionStrings(queryBy).UpdateString();

        public void Read(SqlCommand command, ListManager listManager) => new SqlCommandPrescriptionReader().Read(command, listManager);
    }
}
