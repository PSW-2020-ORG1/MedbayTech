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
        private DateTime occupiedFromDate;
        private DateTime occupiedToDate;

        //   public Bed bed;

        private MedicalRecord.MedicalRecord patient;

        public Occupation(DateTime startDate, DateTime endDate, MedicalRecord.MedicalRecord patient)
        {
            OccupiedFromDate = startDate;
            OccupiedToDate = endDate;
            Patient = patient;
        }

        public DateTime OccupiedFromDate { get => occupiedFromDate; set => occupiedFromDate = value; }
        public DateTime OccupiedToDate { get => occupiedToDate; set => occupiedToDate = value; }

        public MedicalRecord.MedicalRecord Patient { get => patient; set => patient = value; }
    }
}