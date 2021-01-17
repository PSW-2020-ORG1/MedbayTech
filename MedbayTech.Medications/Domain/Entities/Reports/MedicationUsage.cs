using MedbayTech.Common.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Medications.Domain.Entities.Reports
{
    public class MedicationUsage : IIdentifiable<int>
    {
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
        public int MedicationId { get; set; }

        public MedicationUsage() { }

        public MedicationUsage(int id, int usage, DateTime date, int medicationId)
        {
            Id = id;
            Usage = usage;
            MedicationId = medicationId;
            Date = date;
        }

        public bool InPeriod(DateTime from, DateTime until) =>
            from.CompareTo(Date) <= 0 && until.CompareTo(Date) >= 0;

        public int GetId() => Id;
    }
}
