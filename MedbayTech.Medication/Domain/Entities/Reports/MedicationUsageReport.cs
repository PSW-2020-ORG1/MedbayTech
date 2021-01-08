using MedbayTech.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Medications.Domain.Entities.Reports
{
    public class MedicationUsageReport : IIdentifiable<string>
    {
        [Key]
        public string Id { get; set; }
        // NOTE(Jovan): Not working with entity framework, fix!
        //[NotMapped]
        // public Period Period { get; set; }
        [Column(TypeName = "date")]
        public DateTime? From { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Until { get; set; }
        public virtual List<MedicationUsage> MedicationUsages { get; set; }
        public MedicationUsageReport() { }
        public MedicationUsageReport(DateTime from, DateTime until)
        {
            Id = PeriodToString(from, until);
            From = from;
            Until = until;
            MedicationUsages = new List<MedicationUsage>();
        }

        private string PeriodToString(DateTime from, DateTime until)
        {
            string format = "ddMMyy";
            return from.ToString(format) + until.ToString(format) + "_" + DateTime.Now.ToString("ddMMyy_HHmmss");
        }

        public string GetId()
        {
            return Id;
        }

    
    }
}
