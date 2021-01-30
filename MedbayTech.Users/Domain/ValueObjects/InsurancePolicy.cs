/***********************************************************************
 * Module:  InsurancePolicy.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Users.InsurancePolicy
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Common;
using MedbayTech.Common.Domain.ValueObjects;

namespace MedbayTech.Users.Domain.ValueObjects
{
    public class InsurancePolicy : ValueObject
    {
        public string PolicyNumber { get; set; }
        public string Company { get; set; }
        [NotMapped]

        public virtual Period Period {get; set;}

        public InsurancePolicy() { }
        public InsurancePolicy(string policyNumber, string company, Period period)
        {
            PolicyNumber = policyNumber;
            Company = company;
            Period = period;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PolicyNumber;
            yield return Company;
            yield return Period;
        }
    }
}