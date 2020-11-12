// File:    Hospital.cs
// Author:  Vlajkov
// Created: Friday, April 10, 2020 1:34:17 AM
// Purpose: Definition of Class Hospital

using SimsProjekat.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class Hospital : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public string Description { get; protected set; }
        public string Name { get; protected set; }
        [ForeignKey("Address")]
        public int AddressId { get; protected set; }
        public virtual Address Address { get; protected set; }

        public Hospital() { }

        public Hospital(int id, string description, string name, Address address)
        {
            Id = id;
            Description = description;
            Name = name;
            Address = address;
            AddressId = address.Id;
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