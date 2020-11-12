// File:    Occupation.cs
// Author:  Vlajkov
// Created: Thursday, April 23, 2020 7:27:04 PM
// Purpose: Definition of Class Occupations

using Backend.Records.Model.Enums;
using System;

namespace Model.Rooms
{
    public class Occupation
    {
        public DateTime OccupiedFromDate { get; set; }
        public DateTime OccupiedToDate { get; set; }

        public int BedId { get; set; }
        public virtual Bed Bed { get; set; }
        public int PatientId { get; set; }
        public virtual Backend.Records.Model.Enums.MedicalRecord Patient { get; set; }

        public Occupation ( DateTime startDate, DateTime endDate, Backend.Records.Model.Enums.MedicalRecord patient )
        {
            OccupiedFromDate = startDate;
            OccupiedToDate = endDate;
            Patient = patient;
        }

        public Occupation ( )
        {
        }
    }
}