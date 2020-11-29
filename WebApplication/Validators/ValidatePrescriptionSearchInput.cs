using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Validators
{
    public class ValidatePrescriptionSearchInput : ValidateAdvancedSearchInput
    {
        public static void Validate(PrescriptionAdvancedDTO dto)
        {
            Checker(dto.FirstParameterType, dto.FirstParameterValue);

            for (int i = 0; i < dto.OtherParameterValues.Length; i++)
            {
                Checker(dto.OtherParameterTypes[i], dto.OtherParameterValues[i]);
            }
        }

        private static void Checker(string parameterType, string parameterValue)
        {
            if (parameterType.Equals("medication"))
                IsMedicationValid(parameterValue);
            else
                IsHourlyIntakeValid(parameterValue);
        }
    }
}
