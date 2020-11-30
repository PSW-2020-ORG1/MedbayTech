// File:    Hospital.cs
// Author:  Vlajkov
// Created: Friday, April 10, 2020 1:34:17 AM
// Purpose: Definition of Class Hospital

using Backend.General.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class Hospital : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

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