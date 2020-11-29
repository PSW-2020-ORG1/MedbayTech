using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Validators
{
    public class ValidateReportSearchInput : ValidateAdvancedSearchInput
    {
        public static void Validate(ReportAdvancedDTO dto)
        {
            if (dto.FirstParameterType.Equals("docName"))
                IsNameValid(dto.FirstParameterValue);
            else if(dto.FirstParameterType.Equals("docSurname"))
                IsSurnameValid(dto.FirstParameterValue);
            else
                IsDateValid(dto.FirstParameterType);

            for (int i = 0; i < dto.OtherParameterValues.Length; i++)
            {
                if (dto.OtherParameterTypes[i].Equals("docName"))
                    IsNameValid(dto.OtherParameterValues[i]);
                else if (dto.OtherParameterTypes[i].Equals("docSurname"))
                    IsSurnameValid(dto.OtherParameterValues[i]);
                else
                    IsDateValid(dto.OtherParameterValues[i]);
            }
        }
    }
}
