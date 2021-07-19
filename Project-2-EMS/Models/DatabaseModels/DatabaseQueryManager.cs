using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager {

        public DatabaseQueryManager() { }

        public List<PatientAppointment> AppointmentQuery(IAppointmentListQuery sqlQuery) {
            SqlAppointmentReader appointmentReader = new SqlAppointmentReader();            
            BeginQuery(sqlQuery, appointmentReader);
            return appointmentReader.AppointmentList;
        }

        public int CountQuery(ICountQuery sqlQuery) {
            SqlCountReader countReader = new SqlCountReader();
            BeginQuery(sqlQuery, countReader);
            return countReader.Count;
        }

        public void NonReturnQuery(INonQuery sqlQuery) {
            SqlNoReturnReader noReturnReader = new SqlNoReturnReader();
            BeginQuery(sqlQuery, noReturnReader);
        }
        
        public List<Patient> PatientInfoQuery(IPatientInfoListQuery sqlQuery) {
            SqlPatientInfoReader patientInfoReader = new SqlPatientInfoReader();
            BeginQuery(sqlQuery, patientInfoReader);
            return patientInfoReader.PatientList;
        }

        public List<PatientPrescription> PrescriptionQuery(IPrescriptionListQuery sqlQuery) {
            SqlPrescriptionReader prescriptionReader = new SqlPrescriptionReader();
            BeginQuery(sqlQuery, prescriptionReader);
            return prescriptionReader.PrescriptionList;
        }

        private void BeginQuery(ISqlQuery sqlQuery, ISqlReader sqlReader) {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MDR_ConnStr"].ConnectionString)) {
                using (SqlCommand command = new SqlCommand(sqlQuery.GetQueryString(), connection)) {
                                        
                    sqlQuery.AddParameters(command);

                    try {
                        connection.Open();
                        sqlQuery.ExecuteQuery(command, sqlReader);

                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error Executing Database Query:\n{e}");
                    }
                }
            }
        }
    }
}
