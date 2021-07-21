using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_DateRange<T> : IListQuery<T> where T : PatientAppointment {
        private readonly DateTime _StartDate;
        private readonly DateTime _EndDate;

        public SelectAppointmentBy_DateRange(DateTime startDate, DateTime endDate) {
            _StartDate = startDate;
            _EndDate = endDate;
        }

        public List<T> ExecuteQuery(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Appointments WHERE ApptDate BETWEEN @apptStartDate AND @apptEndDate;";
            command.Parameters.Add("@ApptStartDate", SqlDbType.DateTime).Value = _StartDate;
            command.Parameters.Add("@ApptEndDate", SqlDbType.DateTime).Value = _EndDate;

            List<PatientAppointment> list = new List<PatientAppointment>();
            SqlListReader reader = new SqlListReader();

            reader.Read(command, list);

            return list as List<T>;
        }
    }
}
