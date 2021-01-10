// File:    City.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:51 PM
// Purpose: Definition of Class City

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Common;

namespace Model.Users
{
   public class City : ValueObject
    {
        public string Name { get;  set; }      
        [NotMapped]
        public virtual State State { get;  set; }

        public City() { }

        public City(string name, State state)
        {
            Name = name;
            State = state;
           
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return State;
        }
    }
}