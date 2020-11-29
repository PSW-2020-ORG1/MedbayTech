using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
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
            this.FirstParameterValue = firstValue;
            this.FirstParameterType = firstType;
            this.OtherParameterValues = otherValues;
            this.OtherParameterTypes = otherTypes;
            this.LogicOperators = logicOperators;
        }
    }
}
