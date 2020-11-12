// File:    Frequency.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:34:48 PM
// Purpose: Definition of Class Frequency

using System;
using Backend.Records.Model;
using Backend.Records.Model.Enums;

namespace Backend.Medications.Model
{
   public class SideEffect
   {
        public int Id { get; set; }
        public SideEffectFrequency Frequency { get; set; }
        public int SideEffectsId { get; set; }
        public virtual Symptoms SideEffects { get; set; }

        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        public SideEffect() {}
        public SideEffect(SideEffectFrequency frequency, Symptoms symptoms)
        {
            SideEffects = symptoms;
            Frequency = frequency;
        }

        
    }
}