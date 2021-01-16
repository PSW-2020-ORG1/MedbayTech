using MedbayTech.Common.Domain.Common;
using MedbayTech.Common.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Medications.Domain.Entities.Medications
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
