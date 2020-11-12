// File:    City.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:51 PM
// Purpose: Definition of Class City

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get;  set; }
        [ForeignKey("State")]
        public long StateId { get;  set; }
        public virtual State State { get;  set; }

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