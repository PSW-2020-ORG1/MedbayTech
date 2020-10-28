/***********************************************************************
 * Module:  InsurancePolicy.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Users.InsurancePolicy
 ***********************************************************************/

using System;

namespace Model.Users
{
   public class InsurancePolicy
   {
        private string company;
        private string personalInsuranceNumber;
        private DateTime policyStartDate;
        private DateTime policyEndDate;


        public InsurancePolicy() { }
        public InsurancePolicy(string id)
        {
            PersonalInsuranceNumber = id;
        }
        public InsurancePolicy(string company, string personalInsuranceNumber, DateTime policyStartDate, DateTime policyEndDate)
        {
            Company = company;
            PersonalInsuranceNumber = personalInsuranceNumber;
            PolicyStartDate = policyStartDate;
            PolicyEndDate = policyEndDate;
        }

        public string Company { get => company; set => company = value; }
        public string PersonalInsuranceNumber { get => personalInsuranceNumber; set => personalInsuranceNumber = value; }
        public DateTime PolicyStartDate { get => policyStartDate; set => policyStartDate = value; }
        public DateTime PolicyEndDate { get => policyEndDate; set => policyEndDate = value; }
    }
}