using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlListReader : ISqlReader {
        public T Read<T>(SqlCommand command) {
            using (SqlDataReader reader = command.ExecuteReader()) {
                if (typeof(T).Equals(typeof(List<PatientAppointment>))) {
                    List<PatientAppointment> list = new List<PatientAppointment>();
                    ReadAppointment(reader, list);
                    return (T)Convert.ChangeType(list, typeof(T));
                }
                else if (typeof(T).Equals(typeof(List<PatientInfo>))) {
                    List<PatientInfo> list = new List<PatientInfo>();
                    ReadPatientInfo(reader, list);
                    return (T)Convert.ChangeType(list, typeof(T));
                }
                else if (typeof(T).Equals(typeof(List<PatientPrescription>))) {
                    List<PatientPrescription> list = new List<PatientPrescription>();
                    ReadPrescription(reader, list);
                    return (T)Convert.ChangeType(list, typeof(T));
                }
            }

            return default;
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
