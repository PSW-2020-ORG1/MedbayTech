using MedbayTech.Tenders.Application.Common.Interfaces.Gateways;
using MedbayTech.Tenders.Domain.Entities.Pharmacies;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.PharmacyIntegrationTests.PhIntegration.WebApplicationFactory.Gateways
{
    public class PharmacyTenderGateway : IPharmacyGateway
    {
        public Pharmacy Get(string id)
        {
            return GetAll().Find(p => p.Id.Equals(id));
        }

        public List<Pharmacy> GetAll()
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            pharmacies.Add(new Pharmacy("Jankovic", "jankovic123", "jankovic.rs", "jan@gmail.com", true));
            pharmacies.Add(new Pharmacy("Benu", "benu123", "benu.rs", "benu@gmail.com", false));
            pharmacies.Add(new Pharmacy("Zegin", "zegin123", "zegin.rs", "zegin@gmail.com", true));
            pharmacies.Add(new Pharmacy("Dan", "dan123", "dan.rs", "dan@gmail.com", false));
            pharmacies.Add(new Pharmacy("DM", "dm123", "dm.rs", "dm@gmail.com", true));
            return pharmacies;
        }
    }
}
