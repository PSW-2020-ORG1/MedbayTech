// File:    State.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:52 PM
// Purpose: Definition of Class State

using System;
using System.Collections.Generic;

namespace Model.Users
{
   public class State
   {
        private string name;

        public State(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}