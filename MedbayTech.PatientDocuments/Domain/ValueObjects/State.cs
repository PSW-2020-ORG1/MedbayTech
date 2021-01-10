// File:    State.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:52 PM
// Purpose: Definition of Class State

using System.Collections.Generic;
using MedbayTech.Common.Domain.Common;


namespace Model.Users
{
   public class State : ValueObject
   {
        
        public string Name { get;  set; }

        public State () { }
        public State(string name)
        {
            Name = name;
            
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}