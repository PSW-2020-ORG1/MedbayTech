using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Validators
{
    public class ValidateReportSearch : ValidateSearchInput
    {
        public static void Validate(ReportSearchDTO dto)
        {
            IsDoctorNameValid(dto.Doctor);
            IsTypeValid(dto.type);
        }
    }
}
