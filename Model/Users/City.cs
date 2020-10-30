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
        private State state;
        private int id;

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
        public State State { get => state; set => state = value; }
        public int Id { get => id; set => id = value; }
    }
}