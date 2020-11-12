// File:    Hospital.cs
// Author:  Vlajkov
// Created: Friday, April 10, 2020 1:34:17 AM
// Purpose: Definition of Class Hospital

using Model.Rooms;
using System;
using SimsProjekat.Repository;

namespace Model.Users
{
   public class Hospital : IIdentifiable<int>
   {

        public string Description { get; protected set; }
        public string Name { get; protected set; }
        public int Id { get; set; }
        public virtual Address Address { get; protected set; }
        public int AddressId { get; protected set; }

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