// File:    City.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:51 PM
// Purpose: Definition of Class City


using MedbayTech.Common.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Rooms.Domain
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