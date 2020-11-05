// File:    LabResults.cs
// Author:  Vlajkov
// Created: Tuesday, April 21, 2020 2:57:53 PM
// Purpose: Definition of Class LabResults

using System;

namespace Model.MedicalRecord
{
    public class LabResults
    {
        public int Id { get; set; }
        public string ResultType { get; set; }
        public  double Value { get; set; }
        public double MaxRefValue { get; set; }
        public double MinRefValue { get; set; }

        public int ListOfResultsId { get; set; }
        public virtual ListOfResults ListOfResults { get; set; }
        public LabResults() {}
        public LabResults(string resultType, double value, double refValue, double minRef)
        { 
            ResultType = resultType;
            Value = value;
            MaxRefValue = refValue;
            MinRefValue = minRef;
        }
        
    }
}