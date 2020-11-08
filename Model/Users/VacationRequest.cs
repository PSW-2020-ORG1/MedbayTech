// File:    VacationRequest.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 9:27:08 PM
// Purpose: Definition of Class VacationRequest

using System;
using System.Runtime.CompilerServices;
using SimsProjekat.Repository;

namespace Model.Users
{
   public class VacationRequest : IIdentifiable<int>
   {
      public int Id { get; set; }
      public  DateTime FromDate { get; set; }
      public DateTime ToDate { get; set; }
      public string ReasonForVacation { get; set; }
      public bool Approved { get; set; }
      
      public int EmployeeId { get; set; }
      public virtual Employee Employee { get; set; }



        public VacationRequest() { }

        public VacationRequest(int id)
        {
            Id = id;
        }

        public VacationRequest(int id,DateTime fromDate,DateTime toDate,string reasonForVacation,Employee employee)
        {
            Id = id;
            FromDate = fromDate;
            ToDate = toDate;
            ReasonForVacation = reasonForVacation;
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