// File:    Occupation.cs
// Author:  Vlajkov
// Created: Thursday, April 23, 2020 7:27:04 PM
// Purpose: Definition of Class Occupations

using Model.MedicalRecord;
using System;

namespace Model.Rooms
{
    public class Occupation
    {
        public DateTime OccupiedFromDate { get; set; }
        public DateTime OccupiedToDate { get; set; }

        public virtual MedicalRecord.MedicalRecord Patient { get; set; }

        public Occupation ( DateTime startDate, DateTime endDate, MedicalRecord.MedicalRecord patient )
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