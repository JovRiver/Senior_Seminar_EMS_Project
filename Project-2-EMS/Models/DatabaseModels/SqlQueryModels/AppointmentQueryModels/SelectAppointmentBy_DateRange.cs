using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_DateRange : ISqlQuery, ISqlCommandParameters, IAppointmentListQuery {
        private readonly DateTime _StartDate;
        private readonly DateTime _EndDate;

        public SelectAppointmentBy_DateRange(DateTime startDate, DateTime endDate) {
            _StartDate = startDate;
            _EndDate = endDate;
        }

        public void AddParameters(SqlCommand command) {
            command.Parameters.Add("@ApptStartDate", SqlDbType.DateTime).Value = _StartDate;
            command.Parameters.Add("@ApptEndDate", SqlDbType.DateTime).Value = _EndDate;
        }

        public void ExecuteQuery(SqlCommand command, ISqlReader sqlReader) {
            sqlReader.Read(command);
        }

        public string GetQueryString() {
            return "SELECT * FROM Appointments WHERE ApptDate BETWEEN @apptStartDate AND @apptEndDate;";
        }
    }
}
