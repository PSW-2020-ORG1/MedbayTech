// File:    Department.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:59:14 PM
// Purpose: Definition of Class Department

using Model.Users;
using System;
using SimsProjekat.Repository;

namespace Model.Rooms
{
    public class Department : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; protected set; }
        public int Floor { get; set; }
        public virtual Hospital Hospital { get; set; }
        public int HospitalId { get; protected set; }

        public Department (string name, int floor, Hospital hospital)
        {
            Name = name;
            Floor = floor;
            Hospital = hospital;
            HospitalId = hospital.Id;
        }

        public Department (int id)
        {
            this.Id = id;
        }

        public Department ()
        {
        }

        public int GetId ()
        {
            return Id;
        }

        public void SetId (int id)
        {
            Id = id;
        }
    }
}