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
        private int id;
        private DateTime dateOfTesting;
        private List<LabResults> labResults;


        public ListOfResults(DateTime dateOfTesting)
        {
            DateOfTesting = dateOfTesting;
            LabResults = new List<LabResults>();
        }

        public int Id { get => id; set => id = value; }
        public DateTime DateOfTesting { get => dateOfTesting; set => dateOfTesting = value; }
        public List<LabResults> LabResults { get => labResults; set => labResults = value; }
    }
}