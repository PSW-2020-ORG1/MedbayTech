using MedbayTech.Common.Application;
using MedbayTech.PatientDocuments.Application.DTO.Prescription;

namespace MedbayTech.PatientDocuments.Application.Validators.Prescription
{
    public class PrescriptionSearchValidator : InputValidator
    {
        public static void Validate(PrescriptionSearchDTO dto)
        {
            IsMedicineValid(dto.Medicine);
            IsHourlyIntakeValid(dto.HourlyIntake);
        }
    }
}
