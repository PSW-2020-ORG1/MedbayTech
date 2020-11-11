// File:    MedicationConsumptionReport.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 4:20:29 AM
// Purpose: Definition of Class MedicationConsumptionReport

using Backend.Examinations.Model;
using Model.Medications;
using System;
using System.Collections.Generic;

namespace Model.Reports
{
   public class MedicationConsumptionReport : Report
   {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual List<Prescription> Prescriptions { get; set; }


        public MedicationConsumptionReport(DateTime date, DateTime startDate, DateTime endDate, 
            List<Prescription> medications) : base(date, "")
        {
            StartTime = startDate;
            EndTime = endDate;
            Prescriptions = medications;
        }

    
       
    }
}