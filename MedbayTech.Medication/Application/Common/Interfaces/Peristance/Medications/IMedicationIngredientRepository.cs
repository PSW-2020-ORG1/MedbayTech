using MedbayTech.Common.Repository;
using MedbayTech.Medications.Domain.Entities.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications
{
    public interface IMedicationIngredientRepository :  ICreate<MedicationIngredient>, IGetAll<MedicationIngredient>
    {
    }
}
