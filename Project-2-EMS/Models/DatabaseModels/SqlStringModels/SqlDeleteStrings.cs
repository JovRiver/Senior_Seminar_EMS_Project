using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_EMS.Models.DatabaseModels {
    public class SqlDeleteStrings {
        private String PatientAppointmentDeleteParameters(String parameters, String queryBy) {
            switch (queryBy.ToLower()) {
                case "patientid":
                    return "";
                case "visitid":
                    return "";
                case "daterange":
                    return "";
                case "name":
                    return "";
                case "none":
                    return "";
                default:
                    return "";
            }
        }

        private String PatientInfoDeleteParameters(String parameters, String queryBy) {
            switch (queryBy.ToLower()) {
                case "patientid":
                    return "";
                case "visitid":
                    return "";
                case "daterange":
                    return "";
                case "name":
                    return "";
                case "none":
                    return "";
                default:
                    return "";
            }
        }

        private String PatientPrescriptionDeleteParameters(String parameters, String queryBy) {
            switch (queryBy.ToLower()) {
                case "patientid":
                    return "";
                case "visitid":
                    return "";
                case "daterange":
                    return "";
                case "name":
                    return "";
                case "none":
                    return "";
                default:
                    return "";
            }
        }
    }
}
