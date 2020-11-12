// File:    FamilyIllnessHistory.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 1:49:21 AM
// Purpose: Definition of Class FamilyIllnessHistory

using System;
using System.Collections.Generic;

namespace Backend.Records.Model.Enums
{
   public class FamilyIllnessHistory
   {
        public int Id { get; set; }
        public Relative RelativeMember { get; set; }
        public virtual List<Diagnosis> Diagnosis { get; set; }

        public FamilyIllnessHistory() {}
        public FamilyIllnessHistory(Relative relative)
        {
            RelativeMember = relative;
            Diagnosis = new List<Diagnosis>();
        }

       
    }
}