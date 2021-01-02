

using System.ComponentModel.DataAnnotations;

namespace MedbayTech.PatientDocuments.Application.DTO.Report
{
    public class ReportAdvancedDTO
    {
        public string FirstParameterValue { get; set; }
        public string FirstParameterType { get; set; }
        public string[] OtherParameterValues { get; set; }
        public string[] OtherParameterTypes { get; set; }
        public string[] LogicOperators { get; set; }

        public ReportAdvancedDTO() { }
        public ReportAdvancedDTO(string firstValue, string firstType, string[] otherValues, string[] otherTypes, string[] logicOperators)
        {
            FirstParameterValue = firstValue;
            FirstParameterType = firstType;
            OtherParameterValues = otherValues;
            OtherParameterTypes = otherTypes;
            LogicOperators = logicOperators;
        }

    }
}
