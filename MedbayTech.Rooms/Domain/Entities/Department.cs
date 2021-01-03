// File:    Department.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:59:14 PM
// Purpose: Definition of Class Department

using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Rooms.Domain
{
    public class Department : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Floor { get; set; }
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        [NotMapped]
        public virtual Hospital Hospital { get; set; }

        public Department(int id, string name, int floor, Hospital hospital)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Hospital = hospital;
            HospitalId = hospital.Id;
        }

        public Department()
        {
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void UpdateDepartment(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Floor = department.Floor;
            HospitalId = department.HospitalId;
            Hospital = department.Hospital;
        }
    }
}