// File:    Allergens.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:31:19 PM
// Purpose: Definition of Class Allergens

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Common;
using MedbayTech.Repository.Domain.Entities;

namespace Backend.Medications.Model
{
    public class Allergens : ValueObject
    {
        public string Allergen { get; set; }

        public Allergens() { }
        public Allergens(string allergen)
        {
            Allergen = allergen;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Allergen;
        }
    }
}