// File:    VacationRequest.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 9:27:08 PM
// Purpose: Definition of Class VacationRequest

using System;
using System.Runtime.CompilerServices;
using Backend.Utils;
using SimsProjekat.Repository;

namespace Model.Users
{
   public class VacationRequest : IIdentifiable<int>
   {
      public int Id { get; set; }
      public Period Period { get; protected set; }
      public string ReasonForVacation { get; protected set; }
      public bool Approved { get; set; }
      
      public string EmployeeId { get; protected set; }
      public virtual Employee Employee { get;  set; }



        public VacationRequest() { }

        public VacationRequest(int id, Period period, string reasonForVacation, bool approved, Employee employee)
        {
            Id = id;
            Period = period;
            ReasonForVacation = reasonForVacation;
            Employee = employee;
            EmployeeId = employee.Id;
            Approved = approved;
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