// File:    Therapy.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 10:53:47 PM
// Purpose: Definition of Class Therapy

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Medications.Model;
using MedbayTech.Common.Domain.Common;

namespace Backend.Records.Model
{
   public class Therapy : ValueObject
    {
        public int HourConsumption { get; set; }
        public string MedicationName { get; set; }

        public Therapy() {}
        public Therapy(int hourConsumption, string medicationName)
        {
            HourConsumption = hourConsumption;
            MedicationName = medicationName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return HourConsumption;
            yield return MedicationName;
        }
    }
}