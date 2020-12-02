using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiController
{
    public class WebInsuranceController
    {
        private InsurancePolicySqlRepository policyRepository = new InsurancePolicySqlRepository(new MySqlContext());
        private InsurancePolicyService policyService;

        public WebInsuranceController()
        {
            this.policyService = new InsurancePolicyService(policyRepository);
        }

        public InsurancePolicy SavePolicy(InsurancePolicy insurancePolicy)
        {
            return policyService.SavePolicy(insurancePolicy);
        }

    }
}
