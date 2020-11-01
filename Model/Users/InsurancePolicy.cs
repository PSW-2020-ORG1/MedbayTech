/***********************************************************************
 * Module:  InsurancePolicy.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Users.InsurancePolicy
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class InsurancePolicy
   {
        private string company;
        private string id;
        private DateTime policyStartDate;
        private DateTime policyEndDate;



        public InsurancePolicy() { }
        public InsurancePolicy(string id)
        {
            this.id = id;
        }
        public InsurancePolicy(string company, string personalInsuranceNumber, DateTime policyStartDate, DateTime policyEndDate)
        {
            Company = company;
            Id = personalInsuranceNumber;
            PolicyStartDate = policyStartDate;
            PolicyEndDate = policyEndDate;
        }

        public string Company { get => company; set => company = value; }
        public string Id { get => id; set => id = value; }
        public DateTime PolicyStartDate { get => policyStartDate; set => policyStartDate = value; }
        public DateTime PolicyEndDate { get => policyEndDate; set => policyEndDate = value; }
    }
}