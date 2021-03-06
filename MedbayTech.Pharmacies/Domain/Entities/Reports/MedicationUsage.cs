﻿
using MedbayTech.Common.Domain.Entities;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Pharmacies.Domain.Entities.Reports
{
    public class MedicationUsage : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        private int _usage;
        public int Usage
        {
            get => _usage;
            set
            {
                _usage = value < 0 ? 0 : value;
            }
        }
        public DateTime? Date { get; set; }
        [ForeignKey("Medication")]
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        public MedicationUsage() { }

        public MedicationUsage(int id, int usage, DateTime date, Medication medication)
        {
            Id = id;
            Usage = usage;
            Medication = medication;
            MedicationId = Medication.Id;
            Date = date;
        }

        public bool InPeriod(DateTime from, DateTime until) =>
            from.CompareTo(Date) <= 0 && until.CompareTo(Date) >= 0;

        public int GetId() => Id;

    }
}
