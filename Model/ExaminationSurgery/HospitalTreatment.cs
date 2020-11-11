// File:    HospitalTreatment.cs
// Author:  Vlajkov
// Created: Friday, April 10, 2020 12:51:06 AM
// Purpose: Definition of Class HospitalTreatment

using System;
using Model.Rooms;

namespace Examinations
{
   public class HospitalTreatment : Treatment
   {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approved { get; set; } = false;
        public int DepartmentId { get; set; }
        public virtual Department Department{ get; set; }

        public HospitalTreatment(string additionalNotes, DateTime start, DateTime end, Department department) 
            : base(start, additionalNotes, TreatmentType.hospitalTreatment)
        {
            StartDate = start;
            EndDate = end;
            Department = department;
        }

        public HospitalTreatment(int id) : base(id) { }

        public HospitalTreatment() { }

    }
}