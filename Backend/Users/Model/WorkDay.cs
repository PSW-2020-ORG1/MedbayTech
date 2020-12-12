// File:    WorkDay.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 9:01:03 PM
// Purpose: Definition of Class WorkDay

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using Backend.General.Model;

namespace Model.Users
{
    public class WorkDay : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public Days Day { get; protected set; }
        public DateTime Date { get; protected set; }
        [NotMapped]
        public virtual Shift Shift { get; protected set; }
        [ForeignKey("Employee")]
        public string EmployeeId { get; protected set; }
        public virtual Employee Employee { get; set; }

        public WorkDay() { }

        public WorkDay(int id, Days day, DateTime dateTime, Shift shift, Employee employee)
        {
            Id = id;
            Day = day;
            Date = dateTime;
            Shift = shift;
            Employee = employee;
            EmployeeId = employee.Id;
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