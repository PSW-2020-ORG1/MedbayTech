// File:    IMedicationIngredientRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:36 AM
// Purpose: Definition of Interface IMedicationIngredientRepository


using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities.Medications;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications
{
    public interface IMedicationIngredientRepository : ICreate<MedicationIngredient>, IGetAll<MedicationIngredient>
    {
    }
}