using System;

namespace MedbayTech.PatientDocuments.Application.DTO.Report
{
    public class ReportDTO
    {
        public string Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public ReportDTO(string doctor, DateTime date, string type)
        {
            Doctor = doctor;
            Date = date;
            Type = type;
        }

    }
}
