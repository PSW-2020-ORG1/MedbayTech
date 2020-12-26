// File:    State.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:52 PM
// Purpose: Definition of Class State

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Repository.Domain.Entities;

namespace Model.Users
{
   public class State : IIdentifiable<long>
   {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get;  set; }
        public string Name { get;  set; }

        public State () { }
        public State(long id, string name)
        {
            Name = name;
            Id = id;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}