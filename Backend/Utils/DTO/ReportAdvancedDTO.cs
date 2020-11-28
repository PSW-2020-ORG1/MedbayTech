using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class ReportAdvancedDTO
    {
        public string DoctorName { get; set; }
        public string DoctorSurname { get;set; }
        public string AndOr { get; set; }
        public string Diagnosis { get; set; }
        public string DateOfExamination { get; set; }
        public string Allergens { get; set; }

        public ReportAdvancedDTO(string doctorName, string doctorSurname, string andOr, string diagnosis, string date, string allergens)
        {
            this.DoctorName = doctorName;
            this.DoctorSurname = doctorSurname;
            this.AndOr = andOr;
            this.Diagnosis = diagnosis;
            this.DateOfExamination = date;
            this.Allergens = allergens;
        }
    }
}
