using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlAppointmentQuery : ISqlTableQuery {
        public string Delete(string queryBy) => new SqlAppointmentStrings(queryBy).DeleteString();

        public string Insert() => new SqlAppointmentStrings(string.Empty).InsertString();

        public string Select(string queryBy) => new SqlAppointmentStrings(queryBy).SelectString();

        public string Update(string queryBy) => new SqlAppointmentStrings(queryBy).UpdateString();

        public void Read(SqlCommand command, ListManager listManager) => new SqlCommandAppointmentReader().Read(command, listManager);
    }
}
