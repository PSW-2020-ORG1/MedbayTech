// File:    HospitalTreatment.cs
// Author:  Vlajkov
// Created: Friday, April 10, 2020 12:51:06 AM
// Purpose: Definition of Class HospitalTreatment

using System;
using Backend.Examinations.Model.Enums;
using Backend.Utils;
using Model.Rooms;

namespace Backend.Examinations.Model
{
    public class HospitalTreatment : Treatment
    {
        public Period Period { get; set; }
        public Status Status { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public HospitalTreatment(string additionalNotes, DateTime start, DateTime end, Department department)
            : base(start, additionalNotes, TreatmentType.HospitalTreatment)
        {
            this.Period = new Period(start, end);
            Department = department;
            Status = Status.Created;
        }

        public HospitalTreatment(int id) : base(id)
        {
        }

        public HospitalTreatment()
        {
        }

        public bool IsApproved()
        {
            return Status == Status.Approved;
        }
    }

}