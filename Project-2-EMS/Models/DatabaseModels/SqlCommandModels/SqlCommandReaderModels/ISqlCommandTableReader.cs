using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    interface ISqlCommandTableReader {
        void Read(SqlCommand command, ListManager listManager);
    }
}
