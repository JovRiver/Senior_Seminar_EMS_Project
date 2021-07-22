﻿using Project_2_EMS.Models.PatientModels;
using System.Collections.Generic;

namespace Project_2_EMS.Models.DatabaseModels {
    public interface ISqlDatabaseAccess {
        int ExecuteCountQuery(ICountQuery query);
        List<T> ExecuteListQuery<T>(IListQuery<T> query) where T : IPatient;
        bool ExecuteNonQuery(INonQuery query);
    }
}
