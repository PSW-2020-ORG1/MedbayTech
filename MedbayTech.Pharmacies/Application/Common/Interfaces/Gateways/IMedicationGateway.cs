using MedbayTech.Pharmacies.Domain.Entities.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways
{
    public interface IMedicationGateway
    {
        Medication Get(int id);
        List<Medication> GetAll();
    }
}
