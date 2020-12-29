

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


        public void ValidateUserInput()
        {
            CheckInput(FirstParameterType, FirstParameterValue);
            for (int i = 0; i < OtherParameterValues.Length; i++)
                CheckInput(OtherParameterTypes[i], OtherParameterValues[i]);
        }

        private void CheckInput(string firstType, string firstValue)
        {
            if (firstValue.Equals("") || firstValue == null && !firstType.Equals(""))
            {
                if (firstType.Equals("docName"))
                    throw new ValidationException("Doctors name can't be empty");
                else if (firstType.Equals("docSurname"))
                    throw new ValidationException("Doctors surname can't be empty");
                else
                    throw new ValidationException("Date can't be empty");
            }
        }

    }
}
