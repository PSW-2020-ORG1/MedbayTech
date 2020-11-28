using Backend.General.Model;
using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Model
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
        public virtual Medication Medication { get; set; }

        public MedicationUsage() { }

        public MedicationUsage(int id, int usage, Medication medication)
        {
            this.Id = id;
            this.Usage = usage;
            this.Medication = medication;
        }

        public int GetId() => Id;

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}
