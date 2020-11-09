// File:    ListOfResults.cs
// Author:  Vlajkov
// Created: Tuesday, April 21, 2020 3:01:04 PM
// Purpose: Definition of Class ListOfResults

using System;
using System.Collections.Generic;

namespace Model.MedicalRecord
{
    public class ListOfResults
    {
        public int Id { get; set; }
        public DateTime DateOfTesting { get; set; }

        public virtual List<LabResults> LabResults { get; set; }

        public ListOfResults() {}
        public ListOfResults(DateTime dateOfTesting)
        {
            DateOfTesting = dateOfTesting;
            LabResults = new List<LabResults>();
        }

   
    }
}