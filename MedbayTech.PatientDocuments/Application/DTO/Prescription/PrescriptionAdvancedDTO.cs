﻿

namespace MedbayTech.PatientDocuments.Application.DTO.Prescription
{
    public class PrescriptionAdvancedDTO
    {
        public string FirstParameterValue { get; set; }
        public string FirstParameterType { get; set; }
        public string[] OtherParameterValues { get; set; }
        public string[] OtherParameterTypes { get; set; }
        public string[] LogicOperators { get; set; }

        public PrescriptionAdvancedDTO() { }
        public PrescriptionAdvancedDTO(string firstValue, string firstType, string[] otherValues, string[] otherTypes, string[] logicOperators)
        {
            FirstParameterValue = firstValue;
            FirstParameterType = firstType;
            OtherParameterValues = otherValues;
            OtherParameterTypes = otherTypes;
            LogicOperators = logicOperators;
        }

    }
}
