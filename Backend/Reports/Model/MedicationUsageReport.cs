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
    public class MedicationUsageReport : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        // NOTE(Jovan): Not working with entity framework, fix!
        //[NotMapped]
        // public Period Period { get; set; }
        [Column(TypeName = "date")]
        public DateTime? From { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Until { get; set; }
        public virtual List<MedicationUsage> MedicationUsages { get; set; }
        public MedicationUsageReport(){}
        public MedicationUsageReport(int id, DateTime from, DateTime until)
        {
            Id = id;
            From = from;
            Until = until;
            MedicationUsages = new List<MedicationUsage>();
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

    }
}
