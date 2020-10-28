// File:    FamilyIllnessHistory.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 1:49:21 AM
// Purpose: Definition of Class FamilyIllnessHistory

using System;
using System.Collections.Generic;

namespace Model.MedicalRecord
{
   public class FamilyIllnessHistory
   {
        private Relative relativeMember;
        private List<Diagnosis> diagnosis;

        public FamilyIllnessHistory(Relative relative)
        {
            RelativeMember = relative;
            Diagnosis = new List<Diagnosis>();
        }

        public Relative RelativeMember { get => relativeMember; set => relativeMember = value; }
        public List<Diagnosis> Diagnosis { get => diagnosis; set => diagnosis = value; }
    }
}