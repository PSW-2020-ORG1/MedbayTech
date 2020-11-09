/***********************************************************************
 * Module:  InsurancePolicy.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Users.InsurancePolicy
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;

namespace Model.Users
{
   public class InsurancePolicy
   {
        public string Company { get; set; }
        public string Id { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }



        public InsurancePolicy() { }
        public InsurancePolicy(string id)
        {
            Id = id;
        }
        public InsurancePolicy(string company, string personalInsuranceNumber, DateTime policyStartDate, DateTime policyEndDate)
        {
            Company = company;
            Id = personalInsuranceNumber;
            PolicyStartDate = policyStartDate;
            PolicyEndDate = policyEndDate;
        }

    
    }
}