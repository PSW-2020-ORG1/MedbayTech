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
        private string description;
        private string name;
        private int id;
        private Address address;

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

        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public Address Address { get => address; set => address = value; }

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