using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlReader {
        T Read<T>(SqlCommand command);
    }
}
