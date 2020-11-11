// File:    LabTestType.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 10:36:13 PM
// Purpose: Definition of Class LabTestType

using System;

namespace Backend.Examinations.Model
{
   public class LabTestType
    {   
        public int LabTestingId { get; set; }
        public virtual LabTesting LabTesting { get; set; }
        public int Id { get; set; }
        public string TestName { get; set; }

        public LabTestType()
        {

        }

        public LabTestType(string name)
        {
            TestName = name;
        }

    }
}