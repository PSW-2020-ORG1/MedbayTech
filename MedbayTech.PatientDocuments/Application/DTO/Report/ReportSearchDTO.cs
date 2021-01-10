using System;


namespace MedbayTech.PatientDocuments.Application.DTO.Report
{
    public class ReportSearchDTO
    {
        public string Doctor { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string type { get; set; }

        public ReportSearchDTO(string doctor, DateTime startDate, DateTime endDate, string type)
        {
            Doctor = doctor;
            this.startDate = startDate;
            this.endDate = endDate;
            this.type = type;
        }
    }
}
