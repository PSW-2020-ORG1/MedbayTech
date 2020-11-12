// File:    LabTesting.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 10:35:51 PM
// Purpose: Definition of Class LabTesting

using System;
using System.Collections.Generic;
using Backend.Examinations.Model.Enums;

namespace Backend.Examinations.Model
{
   public class LabTesting : Treatment
   {
        public virtual List<LabTestType> LabTestTypes { get; set; }

        public LabTesting() 
            : base (TreatmentType.LabTest)
        {
            LabTestTypes = new List<LabTestType>();
            Date = DateTime.Today;
        }

        public LabTesting(int id) : base(id) { }

    }
}