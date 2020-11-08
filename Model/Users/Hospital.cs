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

        public string Description { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }

        public Hospital() { }

        public Hospital(int id)
        {
            Id = id;
        }

        public Hospital(string descritpion, string name, Address address)
        {
            Description = descritpion;
            Name = name;
            Address = address;
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