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
       public string Street { get; set; }
        public int Number { get; set; }
        public int Apartment { get; set; }

        public int Floor { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }


        public Address() { }
        public Address(int id)
        {
            Id = id;
        }

        public Address(string street, int number, int apartment, int floor, City city)
        {
            Street = street;
            Number = number;
            Apartment = apartment;
            Floor = floor;
            City = city;
        }

            
     
    }
}