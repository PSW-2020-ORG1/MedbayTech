﻿
using MedbayTech.Common.Domain.Common;
using MedbayTech.Common.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Medications.Domain.Entities.Medications
{
    public class MedicationIngredient : ValueObject
    {
        public string Name { get; set; }

        public MedicationIngredient() { }
        public MedicationIngredient(string name)
        {
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
