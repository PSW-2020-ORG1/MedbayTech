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
        private int id;
        private Days day;
        private DateTime date;

        private Shift shift;
        private Employee employee;

        public int shiftId;
        public string employeeId;
      
        public int Id { get => id; set => id = value; }
        public Days Day { get => day; set => day= value; }
        public DateTime Date { get => date; set => date = value; }
        public virtual Shift Shift { get => shift; set => shift= value; }
        public virtual Employee Employee { get => employee; set => employee = value; }

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