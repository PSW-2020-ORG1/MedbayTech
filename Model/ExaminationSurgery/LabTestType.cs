// File:    LabTestType.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 10:36:13 PM
// Purpose: Definition of Class LabTestType

using System;

namespace Model.ExaminationSurgery
{
   public class LabTestType
    {
        public string TestName { get; set; }
        public LabTestType(string name)
        {
            TestName = name;
        }

    }
}