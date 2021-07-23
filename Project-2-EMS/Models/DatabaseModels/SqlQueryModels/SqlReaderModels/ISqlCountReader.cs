using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels{
    public interface ISqlCountReader {
        int Read(SqlCommand command);
    }
}
