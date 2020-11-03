// File:    VacationRequest.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 9:27:08 PM
// Purpose: Definition of Class VacationRequest

using System;
using SimsProjekat.Repository;

namespace Model.Users
{
   public class VacationRequest : IIdentifiable<int>
   {
      private int id;
      private DateTime fromDate;
      private DateTime toDate;
      private string reasonForVacation;
      private bool approved;
      
      public Employee employee;

        public string employeeId;

        public int Id { get => id; set => id = value; }
        public DateTime FromDate { get => fromDate; set => fromDate = value; }
        public DateTime ToDate { get => toDate; set => toDate= value; }
        public string ReasonForVacation { get => reasonForVacation; set => reasonForVacation = value; }
        public bool Approved { get => approved; set => approved = value; }
        public virtual Employee Employee { get => employee; set => employee = value; }

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