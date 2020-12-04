using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    public interface IInsurancePolicyService
    {
        InsurancePolicy SavePolicy(InsurancePolicy insurancePolicy);
        bool ExistsById(string id);
    }
}
