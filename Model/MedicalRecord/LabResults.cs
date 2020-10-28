// File:    LabResults.cs
// Author:  Vlajkov
// Created: Tuesday, April 21, 2020 2:57:53 PM
// Purpose: Definition of Class LabResults

using System;

namespace Model.MedicalRecord
{
    public class LabResults
    {
        private string resultType;
        private double value;
        private double maxRefValue;
        private double minRefValue;

        public LabResults(string resultType, double value, double refValue, double minRef)
        {
            ResultType = resultType;
            Value = value;
            MaxRefValue = refValue;
            MinRefValue = minRef;
        }

        public string ResultType { get => resultType; set => resultType = value; }
        public double Value { get => value; set => this.value = value; }
        public double MaxRefValue { get => maxRefValue; set => maxRefValue = value; }
        public double MinRefValue { get => minRefValue; set => minRefValue = value; }
    }
}