// File:    HospitalTreatment.cs
// Author:  Vlajkov
// Created: Friday, April 10, 2020 12:51:06 AM
// Purpose: Definition of Class HospitalTreatment

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Examinations.Model.Enums;
using MedbayTech.Common.Domain.ValueObjects;

namespace Backend.Examinations.Model
{
    public class HospitalTreatment : Treatment
    {
        [NotMapped]
        public Period Period { get; set; }
        public Status Status { get; set; }
        public int DepartmentId { get; set; }

        public HospitalTreatment(string additionalNotes, DateTime start, DateTime end, int departmentId)
            : base(start, additionalNotes, TreatmentType.HospitalTreatment)
        {
            this.Period = new Period(start, end);
            Status = Status.Created;
            DepartmentId = departmentId;
        }

        public HospitalTreatment(int id) : base(id)
        {
        }

        public HospitalTreatment() : base(TreatmentType.HospitalTreatment) { }

        public bool IsApproved()
        {
            return Status == Status.Approved;
        }
    }

}