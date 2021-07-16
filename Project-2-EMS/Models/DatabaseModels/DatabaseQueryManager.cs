using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager {
        private List<Patient> Patients;
        private List<PatientAppointment> Appointments;
        private List<PatientPrescription> Prescriptions;

        public List<PatientAppointment> QueryAppointments(SqlCommandParameters parameters, SqlQueryManager queryManager) {
            Appointments = new List<PatientAppointment>();
            AppointmentQueryStrings appointmentQuery = new AppointmentQueryStrings();
            ExecuteQuery(parameters, queryManager, appointmentQuery);
            return Appointments;
        }

        public List<Patient> QueryPatients(SqlCommandParameters parameters, SqlQueryManager queryManager) {
            Patients = new List<Patient>();
            PatientInfoQueryStrings patientInfoQuery = new PatientInfoQueryStrings();
            ExecuteQuery(parameters, queryManager, patientInfoQuery);
            return Patients;
        }

        public List<PatientPrescription> QueryPrescriptions(SqlCommandParameters parameters, SqlQueryManager queryManager) {
            Prescriptions = new List<PatientPrescription>();
            PrescriptionQueryStrings prescriptionQuery = new PrescriptionQueryStrings();
            ExecuteQuery(parameters, queryManager, prescriptionQuery);
            return Prescriptions;
        }

        private void ExecuteQuery(SqlCommandParameters parameters, SqlQueryManager queryManager, ITableQueryStrings tableQuery) {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MDR_ConnStr"].ConnectionString)) {
                using (SqlCommand command = new SqlCommandManager().CreateCommandWithParameters(parameters, connection, queryManager)) {
                    try {
                        connection.Open();
                        switch (queryManager.QueryType.ToLower()) {
                            case "delete":
                                _ = command.ExecuteNonQuery();
                                break;
                            case "insert":
                                _ = command.ExecuteNonQuery();
                                break;
                            case "select":
                                using (SqlDataReader dataReader = command.ExecuteReader()) {
                                    ExecuteDataReader(dataReader, "place holder");
                                }
                                break;
                            case "update":
                                _ = command.ExecuteNonQuery();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error Executing Database Query:\n{e}");
                    }
                }
            }
        }

        private void ExecuteDataReader(SqlDataReader dataReader, string returnName) {
            switch (returnName) {
                case nameof(Appointments):
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
                        Appointments.Add(appointment);
                    }
                    break;
                case nameof(Patients):
                    while (dataReader.Read()) {
                        int patientId = dataReader.GetInt32(0);
                        string lastName = dataReader.GetString(1);
                        string firstName = dataReader.GetString(2);
                        string address = dataReader.GetString(3);
                        decimal balance = dataReader.GetDecimal(4);

                        Patient patient = new Patient(patientId, firstName, lastName, address, balance);
                        Patients.Add(patient);
                    }
                    break;
                case nameof(Prescriptions):
                    while (dataReader.Read()) {
                        int prescriptionId = dataReader.GetInt32(0);
                        int patientId = dataReader.GetInt32(1);
                        int visitId = dataReader.GetInt32(2);
                        string prescriptionName = dataReader.GetString(3);
                        string prescriptionNotes = dataReader.GetString(4);
                        byte refills = dataReader.GetByte(5);

                        PatientPrescription prescription = new PatientPrescription(prescriptionId, patientId, visitId, prescriptionName, prescriptionNotes, refills);
                        Prescriptions.Add(prescription);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
