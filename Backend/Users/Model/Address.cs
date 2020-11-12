// File:    Address.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:29:00 PM
// Purpose: Definition of Class Address

using System;

namespace Model.Users
{
   public class Address
   {
       public int Id { get; set; } 
       public string Street { get; protected set; }
        public int Number { get; protected set; }
        public int Apartment { get; protected set; }

        public int Floor { get; protected set; }

        public int CityId { get; protected set; }
        public virtual City City { get; set; }


        public Address() { }

        public Address(int id, string street, int number, int apartment, int floor, City city)
        {
            Id = id;
            Street = street;
            Number = number;
            Apartment = apartment;
            Floor = floor;
            City = city;
            CityId = city.Id;
        }

            
     
    }
}