using MedbayTech.Tenders.Domain.Entities.Medications;
using System;
using System.Collections.Generic;

namespace MedbayTech.Tenders.Application.Common.Interfaces.Gateways
{
    public interface IMedicationGateway
    {
        Medication Get(int id);
        List<Medication> GetAll();
    }
}
