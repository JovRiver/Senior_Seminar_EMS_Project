using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlListReader {
        public List<T> Read<T>(SqlCommand command, List<T> list) {
            using (SqlDataReader reader = command.ExecuteReader()) {
                if ((list as List<PatientAppointment>) != null) {
                    ReadAppointment(reader, list);
                }
                else if ((list as List<PatientInfo>) != null) {
                    ReadPatientInfo(reader, list);
                }
                else if ((list as List<PatientPrescription>) != null) {
                    ReadPrescription(reader, list);
                }
            }

            return list;
        }

        private void ReadAppointment<T>(SqlDataReader reader, List<T> list) {
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
                (list as List<PatientAppointment>).Add(appointment);
            }
        }

        private void ReadPatientInfo<T>(SqlDataReader reader, List<T> list) {
            while (reader.Read()) {
                int patientId = reader.GetInt32(0);
                string lastName = reader.GetString(1);
                string firstName = reader.GetString(2);
                string address = reader.GetString(3);
                decimal balance = reader.GetDecimal(4);

                PatientInfo patient = new PatientInfo(patientId, firstName, lastName, address, balance);
                (list as List<PatientInfo>).Add(patient);
            }
        }

        private void ReadPrescription<T>(SqlDataReader reader, List<T> list) {
            while (reader.Read()) {
                int prescriptionId = reader.GetInt32(0);
                int patientId = reader.GetInt32(1);
                int visitId = reader.GetInt32(2);
                string prescriptionName = reader.GetString(3);
                string prescriptionNotes = reader.GetString(4);
                byte refills = reader.GetByte(5);

                PatientPrescription prescription = new PatientPrescription(prescriptionId, patientId, visitId, prescriptionName, prescriptionNotes, refills);
                (list as List<PatientPrescription>).Add(prescription);
            }
        }
    }
}
