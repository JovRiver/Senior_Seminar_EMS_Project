using Project_2_EMS.Models.PatientModels;
using System;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlCommandAppointmentReader : ISqlCommandTableReader {
        public void Read(SqlCommand command, ListManager listManager) {
            using (SqlDataReader dataReader = command.ExecuteReader()) {
                while (dataReader.Read()) {
                    int visitId = dataReader.GetInt32(0);
                    int patientId = dataReader.GetInt32(1);
                    DateTime apptDate = dataReader.GetDateTime(2);
                    TimeSpan apptTime = dataReader.GetTimeSpan(3);
                    decimal cost = dataReader.GetDecimal(4);
                    string receptNote = dataReader.GetString(5);
                    string nurseNote = dataReader.GetString(6);
                    string doctorNote = dataReader.GetString(7);

                    PatientAppointment appointment = new PatientAppointment(visitId, patientId, apptDate, apptTime, cost, receptNote, nurseNote, doctorNote);
                    listManager.AppointmentList.Add(appointment);
                }
            }
        }
    }
}
