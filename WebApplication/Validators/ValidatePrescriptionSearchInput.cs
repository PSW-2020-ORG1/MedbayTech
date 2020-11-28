using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Validators
{
    public class ValidatePrescriptionSearchInput : ValidateAuthInput
    {
        public static void Validate(PrescriptionAdvancedDTO dto)
        {
            IsMedicationValid(dto.Medication);
            IsHourlyIntakeValid(dto.HourlyIntake);
        }
    }
}
