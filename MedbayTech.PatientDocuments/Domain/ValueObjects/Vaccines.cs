
// File:    Vaccines.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 7:47:44 PM
// Purpose: Definition of Class Vaccines

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Common;

namespace Backend.Records.Model
{
   public class Vaccines : ValueObject
    {
        public string Name { get; set; }

        public Vaccines() {}
        public Vaccines(string name)

        {
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}