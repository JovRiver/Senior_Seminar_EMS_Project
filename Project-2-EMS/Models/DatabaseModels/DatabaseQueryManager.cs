using Project_2_EMS.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_2_EMS.Models.DatabaseModels {
    public class DatabaseQueryManager {

        public DatabaseQueryManager() { }

        public List<PatientAppointment> AppointmentQuery(IAppointmentListQuery sqlQuery) {
            SqlAppointmentReader appointmentReader = new SqlAppointmentReader();
            _ = BeginQuery(sqlQuery, appointmentReader);
            return appointmentReader.AppointmentList;
        }

        public int CountQuery(ICountQuery sqlQuery) {
            SqlCountReader countReader = new SqlCountReader();
            _ = BeginQuery(sqlQuery, countReader);
            return countReader.Count;
        }

        public bool NonReturnQuery(INonQuery sqlQuery) {
            SqlNonReturnReader noReturnReader = new SqlNonReturnReader();
            return BeginQuery(sqlQuery, noReturnReader);
        }

        public List<PatientInfo> PatientInfoQuery(IPatientInfoListQuery sqlQuery) {
            SqlPatientInfoReader patientInfoReader = new SqlPatientInfoReader();
            _ = BeginQuery(sqlQuery, patientInfoReader);
            return patientInfoReader.PatientList;
        }

        public List<PatientPrescription> PrescriptionQuery(IPrescriptionListQuery sqlQuery) {
            SqlPrescriptionReader prescriptionReader = new SqlPrescriptionReader();
            _ = BeginQuery(sqlQuery, prescriptionReader);
            return prescriptionReader.PrescriptionList;
        }

        private bool BeginQuery(ISqlQuery sqlQuery, ISqlReader sqlReader) {
            try {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|App_Data\EMR_DB.mdf; Integrated Security=True")) {
                    using (SqlCommand command = new SqlCommand(sqlQuery.GetQueryString(), connection)) {
                        connection.Open();

                        if ((sqlQuery as ISqlCommandParameters) != null) {
                            (sqlQuery as ISqlCommandParameters).AddParameters(command);
                        }
                        try {
                            sqlQuery.ExecuteQuery(command, sqlReader);
                        }
                        catch (Exception e) {
                            Console.WriteLine($"Error Executing Database Query:\n{e}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine($"Error Setting up Database connection and command:\n{e}");
                return false;
            }
            return true;
        }
    }
}
