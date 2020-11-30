// File:    Department.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:59:14 PM
// Purpose: Definition of Class Department

using Model.Users;
using System;
using Backend.General.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Rooms
{
    public class Department : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        public Department (int id, string name, int floor, Hospital hospital)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Hospital = hospital;
            HospitalId = hospital.Id;
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