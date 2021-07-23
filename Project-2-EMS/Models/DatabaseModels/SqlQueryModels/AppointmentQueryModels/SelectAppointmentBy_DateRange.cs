using Project_2_EMS.Models.PatientModels;
using System;
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

        public SqlCommand SetupSqlCommand(SqlConnection connection) {
            SqlCommand command = new SqlCommand() {
                Connection = connection,
                CommandText = "SELECT * FROM Appointments WHERE ApptDate BETWEEN @apptStartDate AND @apptEndDate;"
            };
            command.Parameters.Add("@ApptStartDate", SqlDbType.DateTime).Value = _StartDate;
            command.Parameters.Add("@ApptEndDate", SqlDbType.DateTime).Value = _EndDate;

            return command;
        }
    }
}
