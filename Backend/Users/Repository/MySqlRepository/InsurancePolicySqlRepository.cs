using Model;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    public class InsurancePolicySqlRepository : MySqlrepository<InsurancePolicy, string>,
        IInsurancePolicyRepository
    {

        public InsurancePolicySqlRepository(MySqlContext context) : base(context) { }
        public bool ExistsById(string id)
        {
            if (GetAll().FirstOrDefault(i => i.Id.Equals(id)) != null) return true;
            return false;
        }
    }
}
