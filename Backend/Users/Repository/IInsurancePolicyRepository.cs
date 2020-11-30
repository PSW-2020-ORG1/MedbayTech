using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository
{
    public interface IInsurancePolicyRepository : IRepository<InsurancePolicy, string>
    {
        public bool ExistsById(string id);
    }
}
