// File:    Therapy.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 10:53:47 PM
// Purpose: Definition of Class Therapy

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords
{
    public class Therapy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int HourConsumption { get; set; }
        public string MedicationName { get; set; }
        public int MedicalRecordId { get; set; }
        public Therapy() { }
        public Therapy(int hourConsumption, string medicationName)
        {
            HourConsumption = hourConsumption;
            MedicationName = medicationName;
        }

    }
}