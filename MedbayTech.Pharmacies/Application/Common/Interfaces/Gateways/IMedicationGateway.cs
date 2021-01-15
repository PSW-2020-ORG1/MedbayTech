using MedbayTech.Pharmacies.Domain.Entities.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways
{
    public interface IMedicationGateway
    {
        public Medication Create(Medication medication);
        public Medication Update(Medication medication);
        public Medication GetBy(int id);

        public List<Medication> GetAll();
    }
}
