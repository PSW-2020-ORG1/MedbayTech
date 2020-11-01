// File:    State.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:52 PM
// Purpose: Definition of Class State

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class State
   {
        public long Id { get; set; }
        private string name;

        public State(string name, long id)
        {
            Name = name;
            Id = Id;
        }

        public string Name { get => name; set => name = value; }
        
    }
}