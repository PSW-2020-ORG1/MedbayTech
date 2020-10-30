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
        private int id;
        private string name;
        private int floor;
        private Hospital hospital;

        public Department(string name, int floor, Hospital hospital)
        {
            Name = name;
            Floor = floor;
            Hospital = hospital;
        }
        
        public Department(int id)
        {
            Id = id;
        }

        public Department() { }

        public string Name{ get => name; set => name = value;}
        public int Floor { get => floor; set => floor = value; }
        public int DepartmentID { get => Id; set => Id = value; }
        public Hospital Hospital { get => hospital; set => hospital = value; }
        public int Id { get => id; set => id = value; }

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