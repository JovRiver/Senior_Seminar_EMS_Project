using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SelectAppointmentBy_Date_PatientId : IListQuery {
        private readonly DateTime _AppointmentDate;
        private readonly int _PatientId;

        public SelectAppointmentBy_Date_PatientId(DateTime appointmentDate, int patientId) {
            _AppointmentDate = appointmentDate;
            _PatientId = patientId;
        }

        public List<T> ExecuteQuery<T>(SqlConnection connection, SqlCommand command) {
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Appointments WHERE ApptDate = @apptDate AND PatientID = @patientId;";
            command.Parameters.Add("@apptDate", SqlDbType.DateTime).Value = _AppointmentDate;
            command.Parameters.Add("@patientID", SqlDbType.Int).Value = _PatientId;

            List<PatientAppointment> list = new List<PatientAppointment>();
            SqlListReader reader = new SqlListReader();

            reader.Read(command, list);

            return list as List<T>;
        }
    }
}
