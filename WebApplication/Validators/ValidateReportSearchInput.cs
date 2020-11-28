using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Validators
{
    public class ValidateReportSearchInput : ValidateAuthInput
    {
        public static void Validate(ReportAdvancedDTO dto)
        {
            IsNameValid(dto.DoctorName);
            IsSurnameValid(dto.DoctorSurname);
            IsDiagnosisValid(dto.Diagnosis);
            IsAllergenValid(dto.Allergens);
            IsDateValid(dto.DateOfExamination);
        }
    }
}
