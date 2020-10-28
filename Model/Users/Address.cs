// File:    Address.cs
// Author:  Vlajkov
// Created: Monday, April 06, 2020 11:29:00 PM
// Purpose: Definition of Class Address

using System;

namespace Model.Users
{
   public class Address
   {
        int id;
        private string street;
        private int number;
        private int apartment;
        private int floor;
        private City city;


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

            
        public string Street { get => street; set => street = value; }
        public int Number { get => number; set => number = value; }
        public int Apartment { get => apartment; set => apartment = value; }
        public int Floor { get => floor; set => floor = value; }
        public City City { get => city; set => city = value; }
        public int Id { get => id; set => id = value; }
    }
}