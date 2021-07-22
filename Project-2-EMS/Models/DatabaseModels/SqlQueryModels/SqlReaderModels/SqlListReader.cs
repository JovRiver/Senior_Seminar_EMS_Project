using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlListReader<T> {
        private readonly List<T> TableList = new List<T>();

        public List<T> Read(SqlCommand command) {
            using (SqlDataReader reader = command.ExecuteReader()) {
                if ((TableList as List<PatientAppointment>) != null) { ReadAppointment(reader); }
                else if ((TableList as List<PatientInfo>) != null) { ReadPatientInfo(reader); }
                else if ((TableList as List<PatientPrescription>) != null) { ReadPrescription(reader); }
            }

            return TableList;
        }

        private void ReadAppointment(SqlDataReader reader) {
            while (reader.Read()) {
                int visitId = reader.GetInt32(0);
                int patientId = reader.GetInt32(1);
                DateTime apptDate = reader.GetDateTime(2);
                TimeSpan apptTime = reader.GetTimeSpan(3);
                decimal cost = reader.GetDecimal(4);
                string receptNote = reader.GetString(5);
                string nurseNote = reader.GetString(6);
                string doctorNote = reader.GetString(7);

                PatientAppointment appointment = new PatientAppointment(visitId, patientId, apptDate, apptTime, cost, receptNote, nurseNote, doctorNote);
                (TableList as List<PatientAppointment>).Add(appointment);
            }
        }

        private void ReadPatientInfo(SqlDataReader reader) {
            while (reader.Read()) {
                int patientId = reader.GetInt32(0);
                string lastName = reader.GetString(1);
                string firstName = reader.GetString(2);
                string address = reader.GetString(3);
                decimal balance = reader.GetDecimal(4);

                PatientInfo patient = new PatientInfo(patientId, firstName, lastName, address, balance);
                (TableList as List<PatientInfo>).Add(patient);
            }
        }

        private void ReadPrescription(SqlDataReader reader) {
            while (reader.Read()) {
                int prescriptionId = reader.GetInt32(0);
                int patientId = reader.GetInt32(1);
                int visitId = reader.GetInt32(2);
                string prescriptionName = reader.GetString(3);
                string prescriptionNotes = reader.GetString(4);
                byte refills = reader.GetByte(5);

                PatientPrescription prescription = new PatientPrescription(prescriptionId, patientId, visitId, prescriptionName, prescriptionNotes, refills);
                (TableList as List<PatientPrescription>).Add(prescription);
            }
        }
    }
}
