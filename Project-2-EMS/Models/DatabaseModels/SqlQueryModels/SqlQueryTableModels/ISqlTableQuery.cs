using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlTableQuery {
        string Delete(string queryBy);
        string Insert();
        string Select(string queryBy);
        string Update(string queryBy);

        void Read(SqlCommand command, ListManager listManager);
    }
}
