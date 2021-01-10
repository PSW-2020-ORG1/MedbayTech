﻿using Backend.General.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Backend.Pharmacies.Model
{
    public class UrgentMedicationProcurement : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDosage { get; set; }
        public int MedicationQuantity { get; set; }

        public UrgentMedicationProcurement(string medicationName, string medicationDosage, int medicationQuantity)
        {
            MedicationName = medicationName;
            MedicationDosage = medicationDosage;
            MedicationQuantity = medicationQuantity;
        }

        public UrgentMedicationProcurement()
        {
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
