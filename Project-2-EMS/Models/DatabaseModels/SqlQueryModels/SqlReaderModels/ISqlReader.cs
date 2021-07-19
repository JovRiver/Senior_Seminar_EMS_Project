using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlReader {
        void Read(SqlCommand command);
    }
}
