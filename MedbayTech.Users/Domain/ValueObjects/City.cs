// File:    City.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:20:51 PM
// Purpose: Definition of Class City

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Repository.Domain.Entities;

namespace Model.Users
{
   public class City : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}