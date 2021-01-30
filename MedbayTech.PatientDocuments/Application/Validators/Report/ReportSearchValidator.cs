﻿using MedbayTech.PatientDocuments.Application.DTO.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.Validators.Report
{
    public class ReportSearchValidator : AdvancedSearchValidator
    {
        public static void Validate(ReportAdvancedDTO dto)
        {
            Checker(dto.FirstParameterType, dto.FirstParameterValue);

            for (int i = 0; i < dto.OtherParameterValues.Length; i++)
            {
                Checker(dto.OtherParameterTypes[i], dto.OtherParameterValues[i]);
            }
        }

        private static void Checker(string parameterType, string parameterValue)
        {
            if (parameterType.Equals("docName"))
                IsNameValid(parameterValue);
            else if (parameterType.Equals("docSurname"))
                IsSurnameValid(parameterValue);
            else
                IsDateValid(parameterValue);
        }
    }
}
