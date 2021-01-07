﻿

using MedbayTech.Common.Repository;
using MedbayTech.Pharmacies.Domain.Entities;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance
{
    public interface IPharmacyRepository : IRepository<Pharmacy, string>
    {
    }
}
