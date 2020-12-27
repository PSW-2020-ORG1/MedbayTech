// File:    Specialization.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:27:27 PM
// Purpose: Definition of Class Specialization

using MedbayTech.Common.Domain.Common;
using System.Collections.Generic;

namespace Model.Users
{
    public class Specialization : ValueObject
    {
        public string SpecializationName { get; set; }

        public Specialization(string name)
        {
            SpecializationName = name;
        }

        public Specialization()
        {

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SpecializationName;
        }
    }
    
}