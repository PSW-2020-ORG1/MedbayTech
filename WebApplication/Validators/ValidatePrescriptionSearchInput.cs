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
            if(dto.FirstParameterType.Equals("medication"))
                IsMedicationValid(dto.FirstParameterValue);
            else
                IsHourlyIntakeValid(dto.FirstParameterValue);

            for (int i = 0; i < dto.OtherParameterValues.Length; i++)
            {
                if (dto.OtherParameterTypes[i].Equals("medication"))
                    IsMedicationValid(dto.OtherParameterValues[i]);
                else
                    IsHourlyIntakeValid(dto.OtherParameterValues[i]);
            }
        }
    }
}
