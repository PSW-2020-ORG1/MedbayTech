/***********************************************************************
 * Module:  InsurancePolicy.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Users.InsurancePolicy
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MedbayTech.Repository.Domain.Entities;

namespace Model.Users
{
   public class InsurancePolicy : IIdentifiable<string>
    {
        [Key]
        public string Id { get; set; }
        public string Company { get; set; }

     

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public InsurancePolicy() { }
        public InsurancePolicy(string id, string company, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Company = company;
            StartTime = startDate;
            EndTime = endDate;
        }

        public string GetId()
        {
            return Id;
        }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}