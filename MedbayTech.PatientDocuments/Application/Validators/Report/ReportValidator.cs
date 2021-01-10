using MedbayTech.Common.Application;
using MedbayTech.PatientDocuments.Application.DTO.Report;

namespace MedbayTech.PatientDocuments.Application.Validators.Report
{
    public class ReportValidator : InputValidator
    {
        public static void Validate(ReportSearchDTO dto)
        {
            IsNameValid(dto.Doctor);
            IsTypeValid(dto.type);
        }
    }
}
