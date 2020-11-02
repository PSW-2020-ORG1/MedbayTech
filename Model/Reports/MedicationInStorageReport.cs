// File:    MedicationInStorageReport.cs
// Author:  Vlajkov
// Created: Thursday, May 28, 2020 9:11:56 PM
// Purpose: Definition of Class MedicationInStorageReport

using Model.Medications;
using System;
using System.Collections.Generic;

namespace Model.Reports
{
   public class MedicationInStorageReport : Report
   {
        public virtual List<Medication> Medications { get; set; }

        public MedicationInStorageReport(DateTime date, string content, List<Medication> medications) : base(date, content)
        {
            Medications = medications;
        }

        
    }
}