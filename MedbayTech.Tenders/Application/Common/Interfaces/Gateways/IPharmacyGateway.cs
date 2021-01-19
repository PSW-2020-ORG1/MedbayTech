using MedbayTech.Tenders.Domain.Entities.Pharmacies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Tenders.Application.Common.Interfaces.Gateways
{
    public interface IPharmacyGateway
    {
        Pharmacy Get(string id);
        List<Pharmacy> GetAll();
    }
}
