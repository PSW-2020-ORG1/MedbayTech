using PharmacyIntegration.Model;
using Repository;
using System;
using System.Collections.Generic;

namespace PharmacyIntegration.Repository
{
    public interface IPharmacyRepository : IRepository<Pharmacy, string>
    {
    }
}
