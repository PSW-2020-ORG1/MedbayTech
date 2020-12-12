// File:    Address.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:29:00 PM
// Purpose: Definition of Class Address

using Backend.General.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class Address : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; } 
        public string Street { get;  set; }
        public int Number { get;  set; }
        public int Apartment { get;  set; }

        public int Floor { get;  set; }
        [ForeignKey("City")]
        public int CityId { get;  set; }
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