// File:    City.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:51 PM
// Purpose: Definition of Class City

using System;
using System.Collections.Generic;

namespace Model.Users
{
   public class City
   {
        public string Name { get; protected set; }

        public long StateId { get; protected set; }
        public virtual State State { get; protected set; }
        public int Id { get; set; }

        public City() { }

        public City(int id, string name, State state)
        {
            Name = name;
            State = state;
            StateId = state.Id;
            Id = id;
        }
    }
}