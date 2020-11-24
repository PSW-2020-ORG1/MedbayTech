using PharmacyIntegration.Model;
using PharmacyIntegration.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Pharmacies.Repository.MySqlRepository
{
    public class PharmacySqlRepository : MySqlrepository<Pharmacy, string>,
        IPharmacyRepository
    {
    }
}
