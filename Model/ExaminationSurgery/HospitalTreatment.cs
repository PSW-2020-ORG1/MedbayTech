// File:    HospitalTreatment.cs
// Author:  Vlajkov
// Created: Friday, April 10, 2020 12:51:06 AM
// Purpose: Definition of Class HospitalTreatment

using System;
using Model.Rooms;

namespace Model.ExaminationSurgery
{
   public class HospitalTreatment : Treatment
   {
        private DateTime startDate;
        private DateTime endDate;
        private bool approved = false;
        private Department department;

        public HospitalTreatment(string additionalNotes, DateTime start, DateTime end, Department department) 
            : base(start, additionalNotes, TreatmentType.hospitalTreatment)
        {
            StartDate = start;
            EndDate = end;
            Department = department;
        }

        public HospitalTreatment(int id) : base(id) { }

        public HospitalTreatment() { }

        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public bool Approved { get => approved; set => approved = value; }
        public Department Department { get => department; set => department = value; }
    }
}