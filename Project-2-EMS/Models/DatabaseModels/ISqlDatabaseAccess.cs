using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlDatabaseAccess {
        int ExecuteCountQuery(ICountCommand query);
        List<T> ExecuteListQuery<T>(ISelectCommand<T> query) where T : IPatient;
        bool ExecuteNonQuery(INonQueryCommand query);
    }
}
