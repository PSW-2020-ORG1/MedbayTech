// File:    State.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:52 PM
// Purpose: Definition of Class State

using System.ComponentModel.DataAnnotations;

namespace Model.Users
{
   public class State
   {
        [Key]
        public long Id { get;  set; }
        public string Name { get;  set; }

        public State () { }
        public State(long id, string name)
        {
            Name = name;
            Id = id;
        }

      
        
    }
}