/***********************************************************************
 * Module:  InsurancePolicy.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Users.InsurancePolicy
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Utils;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;

namespace Model.Users
{
   public class InsurancePolicy
   {
        public string Company { get; protected set; }
        public string Id { get; protected set; }
        public Period Period { get; set; }



        public InsurancePolicy() { }
        public InsurancePolicy(string id, string company, Period period)
        {
            Id = id;
            Company = company;
            Period = period;
        }

    
    }
}