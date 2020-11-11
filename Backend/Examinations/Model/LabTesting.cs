// File:    LabTesting.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 10:35:51 PM
// Purpose: Definition of Class LabTesting

using System;
using System.Collections.Generic;

namespace Backend.Examinations.Model
{
   public class LabTesting : Treatment
   {
        public virtual List<LabTestType> LabTestTypes { get; set; }

        public LabTesting(DateTime date, List<LabTestType> labTypes) 
            : base (date, "", TreatmentType.labTestType)
        {
            LabTestTypes = labTypes;
        }

        public LabTesting(int id) : base(id) { }
        public LabTesting() { }

    }
}