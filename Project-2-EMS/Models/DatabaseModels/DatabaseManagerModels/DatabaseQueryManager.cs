using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager : DatabaseConnectionManager {

        public DatabaseQueryListManager MakeQuery(SqlCommandParameters parameters, String queryBy, String queryType, String listType) {
            DatabaseQueryListManager listManager;

            switch (listType.ToLower()) {
                case "patientappointment":
                    listManager = new DatabaseQueryListManager(appointments: new List<PatientAppointment>());
                    break;
                case "patient":
                    listManager = new DatabaseQueryListManager(patients: new List<Patient>());
                    break;
                case "patientprescription":
                    listManager = new DatabaseQueryListManager(prescriptions: new List<PatientPrescription>());
                    break;
                default: 
                    listManager = new DatabaseQueryListManager();
                    break;
            }

            ExecuteQuery(parameters, queryBy, queryType, listManager);
            return listManager;
        }

        private void ExecuteQuery(SqlCommandParameters parameters, String queryBy, String queryType, DatabaseQueryListManager listManager) {
            using (SqlConnection connection = ConnectToDatabase()) {
                SqlCommandManager commandManager = new SqlCommandManager();
                using (SqlCommand command = commandManager.CreateCommandWithParameters(parameters, queryBy, connection)) {
                    try {
                        connection.Open();
                        switch (queryType.ToLower()) {
                            case "delete":
                                _ = command.ExecuteNonQuery();
                                break;
                            case "query":
                                using (SqlDataReader dataReader = command.ExecuteReader()) {
                                    ExecuteReturnQuery(command, listManager, dataReader);
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
                        Console.WriteLine($"Error Executing SQL Statements:\n{e}");
                    }
                }
            }
        }

        private void ExecuteReturnQuery(SqlCommand command, DatabaseQueryListManager listManager, SqlDataReader dataReader) {
            if (listManager.Appointments != null) {
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
                    listManager.Appointments.Add(appointment);
                }
            }
            else if (listManager.Patients != null) {
                while (dataReader.Read()) {
                    int patientId = dataReader.GetInt32(0);
                    string lastName = dataReader.GetString(1);
                    string firstName = dataReader.GetString(2);
                    string address = dataReader.GetString(3);
                    decimal balance = dataReader.GetDecimal(4);

                    Patient patient = new Patient(patientId, firstName, lastName, address, balance);
                    listManager.Patients.Add(patient);
                }
            }
            else if (listManager.Prescriptions != null) {
                while (dataReader.Read()) {
                    int prescriptionId = dataReader.GetInt32(0);
                    int patientId = dataReader.GetInt32(1);
                    int visitId = dataReader.GetInt32(2);
                    String prescriptionName = dataReader.GetString(3);
                    String prescriptionNotes = dataReader.GetString(4);
                    byte refills = dataReader.GetByte(5);

                    PatientPrescription prescription = new PatientPrescription(prescriptionId, patientId, visitId, prescriptionName, prescriptionNotes, refills);
                    listManager.Prescriptions.Add(prescription);
                }
            }
        }
    }
}
