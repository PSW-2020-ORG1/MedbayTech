// File:    IMedicationCategoryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:35 AM
// Purpose: Definition of Interface IMedicationCategoryRepository

using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities.Medications;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications
{
    public interface IMedicationCategoryRepository : ICreate<MedicationCategory>, IGetAll<MedicationCategory>
    {
    }
}