/***********************************************************************
 * Module:  Medication.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.Medication
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Entities;
using MedbayTech.Common.Domain.Entities.Generalities;
using MedbayTech.Pharmacies.Domain.Entities.Rooms;
using MedbayTech.Pharmacies.Domain.Enums;

namespace MedbayTech.Pharmacies.Domain.Entities.Medications
{
    public class Medication : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Med { get; set; }
        public MedStatus Status { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public int RoomId { get; set; }
        [NotMapped]
        public Room Room { get; set; }
        public virtual List<DosageOfIngredient> MedicationContent { get; set; }
        [ForeignKey("MedicationCategory")]
        public int MedicationCategoryId { get; set; }
        public virtual MedicationCategory MedicationCategory { get; set; }
        public Medication() { }

        public Medication(string name, string company, MedicationCategory category)
        {
            Med = name;
            Company = company;
            MedicationContent = new List<DosageOfIngredient>();
            MedicationCategory = category;
            MedicationCategoryId = category.Id;
            Status = MedStatus.Validation;
        }

        public Medication(int id)
        {
            Id = id;
        }

        public int GetId()
        {
            return Id;
        }


        public bool IsOnValidation()
        {
            return Status == MedStatus.Validation;
        }
        public void UpdateMedication(Medication medication)
        {
            Id = medication.Id;
            Med = medication.Med;
            Status = medication.Status;
            Company = medication.Company;
            Quantity = medication.Quantity;
            Dosage = medication.Dosage;
            Room = medication.Room;
            MedicationContent = medication.MedicationContent;
            MedicationCategoryId = medication.MedicationCategoryId;
            MedicationCategory = medication.MedicationCategory;
        }
    }
}