// File:    IMedicationRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:36 AM
// Purpose: Definition of Interface IMedicationRepository


using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using System.Collections.Generic;


namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications
{
    public interface IMedicationRepository : IRepository<Medication, int>
    {
        List<Medication> GetAllOnValidation();
        List<Medication> GetAllRejected();
        List<Medication> GetAllApproved();

    }
}