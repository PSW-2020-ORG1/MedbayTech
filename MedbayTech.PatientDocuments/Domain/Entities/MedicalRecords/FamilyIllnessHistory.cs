// File:    FamilyIllnessHistory.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 1:49:21 AM
// Purpose: Definition of Class FamilyIllnessHistory

using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords
{
    public class FamilyIllnessHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Relative RelativeMember { get; set; }
        public virtual List<Diagnosis> Diagnosis { get; set; }

        public FamilyIllnessHistory() { }
        public FamilyIllnessHistory(Relative relative)
        {
            RelativeMember = relative;
            Diagnosis = new List<Diagnosis>();
        }

    }
}