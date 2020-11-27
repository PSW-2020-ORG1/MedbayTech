using Backend.Users.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class InsurancePolicyService
    {
        IInsurancePolicyRepository insurancePolicyRepository;

        public InsurancePolicyService(IInsurancePolicyRepository insurancePolicyRepository)
        {
            this.insurancePolicyRepository = insurancePolicyRepository;
        }

        public InsurancePolicy SavePolicy(InsurancePolicy insurancePolicy)
        {
            if(!ExistsById(insurancePolicy.Id))
            {
                return insurancePolicyRepository.Create(insurancePolicy);
            }
            return null;
        }
        public bool ExistsById(string id)
        {
            return insurancePolicyRepository.ExistsById(id);
        }
     
    }
}
