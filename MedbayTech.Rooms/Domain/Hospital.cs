// File:    Hospital.cs
// Author:  Vlajkov
// Created: Friday, April 10, 2020 1:34:17 AM
// Purpose: Definition of Class Hospital


using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Rooms.Domain
{
    public class Hospital : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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