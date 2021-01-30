// File:    Address.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:29:00 PM
// Purpose: Definition of Class Address

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Common;

namespace MedbayTech.Rooms.Domain
{
   public class Address : ValueObject
   {
        
        public string Street { get;  set; }
        public int Number { get;  set; }
        public int Apartment { get;  set; }

        public int Floor { get;  set; }

        [NotMapped]
        public virtual City City { get; set; }


        public Address() { }

        public Address(string street, int number, int apartment, int floor, City city)
        {
            Street = street;
            Number = number;
            Apartment = apartment;
            Floor = floor;
            City = city;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return Apartment;
            yield return Floor;
            yield return City;
            yield return Street;
        }
    }
}