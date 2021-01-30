
// File:    Vaccines.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:47:44 PM
// Purpose: Definition of Class Vaccines

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords
{
    public class Vaccines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicalRecordId { get; set; }
        public Vaccines() { }
        public Vaccines(string name)

        {
            Name = name;
        }

    }
}