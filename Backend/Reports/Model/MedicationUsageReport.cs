using Backend.General.Model;
using Backend.Medications.Model;
using Backend.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Backend.Reports.Model
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
        public MedicationUsageReport(){}
        public MedicationUsageReport(DateTime from, DateTime until)
        {
            Id = PeriodToString(from, until);
            From = from;
            Until = until;
            MedicationUsages = new List<MedicationUsage>();
        }

        private String PeriodToString(DateTime from, DateTime until)
        {
            String format = "ddMMyy";
            return from.ToString(format) + until.ToString(format);
        }

        public string GetId()
        {
            return Id;
        }

        public void SetId(string id)
        {
            Id = id;
        }

    }
}
