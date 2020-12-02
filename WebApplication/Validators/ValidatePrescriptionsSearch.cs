using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Validators
{
    public class ValidatePrescriptionsSearch : ValidateSearchInput
    {
        public static void Validate(PrescriptionSearchDTO dto)
        {
            IsMedicineValid(dto.Medicine);
            IsHourlyIntakeValid(dto.HourlyIntake);
        }
    }
}
