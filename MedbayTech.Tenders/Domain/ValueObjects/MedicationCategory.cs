// File:    MedicationCategory.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:28:21 PM
// Purpose: Definition of Class MedicationCategory

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Common;
using MedbayTech.Common.Domain.Entities;

namespace MedbayTech.Tenders.Domain.Entities.Medications
{
    public class MedicationCategory : ValueObject
    {
        public string CategoryName { get; set; }
        public MedicationCategory() { }
        public MedicationCategory(string categoryName)
        {
            CategoryName = categoryName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CategoryName;
        }
    }
}