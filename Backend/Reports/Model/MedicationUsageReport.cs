using Backend.General.Model;
using Backend.Medications.Model;
using Backend.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Reports.Model
{
    public class MedicationUsageReport : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public Period Period { get; set; }
        public List<Medication> Medications { get; set; }
        public MedicationUsageReport(){}
        public MedicationUsageReport(int id, Period period)
        {
            Id = id;
            Period = period;
            Medications = new List<Medication>();
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
