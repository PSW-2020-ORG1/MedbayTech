// File:    FamilyIllnessHistory.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 1:49:21 AM
// Purpose: Definition of Class FamilyIllnessHistory

using Backend.Records.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Records.Model
{
   public class FamilyIllnessHistory
   {
        [Key]
        public int Id { get; set; }
        public Relative RelativeMember { get; set; }
        public virtual List<Diagnosis> Diagnosis { get; set; }
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        public FamilyIllnessHistory() {}
        public FamilyIllnessHistory(Relative relative)
        {
            RelativeMember = relative;
            Diagnosis = new List<Diagnosis>();
        }

       
    }
}