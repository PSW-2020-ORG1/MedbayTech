// File:    MedicationConsumptionReport.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 4:20:29 AM
// Purpose: Definition of Class MedicationConsumptionReport

using Model.ExaminationSurgery;
using Model.Medications;
using System;
using System.Collections.Generic;

namespace Model.Reports
{
   public class MedicationConsumptionReport : Report
   {
        private DateTime startTime;
        private DateTime endTime;
        private List<Prescription> prescriptions;


        public MedicationConsumptionReport(DateTime date, DateTime startDate, DateTime endDate, 
            List<Prescription> medications) : base(date, "")
        {
            StartTime = startDate;
            EndTime = endDate;
            Prescriptions = medications;
        }

        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public List<Prescription> Prescriptions { get => prescriptions; set => prescriptions = value; }
    }
}