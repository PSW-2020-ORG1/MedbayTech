// File:    Frequency.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:34:48 PM
// Purpose: Definition of Class Frequency

using System;
using Model.MedicalRecord;

namespace Model.Medications
{
   public class SideEffect
   {
        private SideEffectFrequency frequency;

        private Symptoms sideEffects;
        public SideEffect(SideEffectFrequency frequency, Symptoms symptoms)
        {
            this.SideEffects = symptoms;
            this.Frequency = frequency;
        }

        public SideEffectFrequency Frequency { get => frequency; set => frequency = value; }
        public Symptoms SideEffects { get => sideEffects; set => sideEffects = value; }
    }
}