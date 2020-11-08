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
        private string name;

        public long StateId { get; set; }
        public virtual State State {get; set; }
        public int Id { get; set; }

        public City() { }

        public City(int id)
        {
            Id = id;
        }

        public City(string name, State state)
        {
            Name = name;
            State = state;
        }

        public string Name { get => name; set => name = value; }
    }
}