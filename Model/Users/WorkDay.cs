// File:    WorkDay.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 9:01:03 PM
// Purpose: Definition of Class WorkDay

using System;
using System.Security.Policy;
using SimsProjekat.Repository;

namespace Model.Users
{
   public class WorkDay : IIdentifiable<int>
   {
        public int Id { get; set; }
        public Days Day { get; set; }
        public DateTime Date { get; set; }

        public virtual Shift Shift { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int shiftId;
        public string employeeId;
      

        public WorkDay() { }
        
        public WorkDay(int id)
        {
            Id = id;
        }

        public WorkDay(Days day, DateTime dateTime, Shift shift, Employee employee)
        {
            Day = day;
            Date = dateTime;
            Shift = shift;
            Employee = employee;

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