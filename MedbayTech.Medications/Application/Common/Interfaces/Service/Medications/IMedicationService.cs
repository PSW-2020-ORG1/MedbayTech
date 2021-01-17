using MedbayTech.Medications.Domain.Entities.Medications;
using System.Collections.Generic;


namespace MedbayTech.Medications.Application.Common.Interfaces.Service.Medications
{
    public interface IMedicationService
    {
        Domain.Entities.Medications.Medication Add(Domain.Entities.Medications.Medication medication);
        List<Domain.Entities.Medications.Medication> GetAllMedicationsByNameOrId(string textSearchBox);
        Domain.Entities.Medications.Medication RejectMedication(Domain.Entities.Medications.Medication medication);
        List<Domain.Entities.Medications.Medication> GetAllMedicationByRoomId(string textSearchBox);
        Domain.Entities.Medications.Medication ApproveMedication(Domain.Entities.Medications.Medication medication);
        Domain.Entities.Medications.Medication UpdateMedication(Domain.Entities.Medications.Medication medication);
        bool DeleteMedication(Domain.Entities.Medications.Medication medication);
        Domain.Entities.Medications.Medication GetMedication(int id);
        List<Domain.Entities.Medications.Medication> GetAllOnValidation();
        List<Domain.Entities.Medications.Medication> GetAll();
        List<Domain.Entities.Medications.Medication> GetAllRejected();
        List<Domain.Entities.Medications.Medication> GetAllApproved();
        Domain.Entities.Medications.Medication AddAmount (Domain.Entities.Medications.Medication medication, int amount);
        Domain.Entities.Medications.Medication UpdateDosageOfIngredients( Domain.Entities.Medications.Medication medication, DosageOfIngredient dosageOfIngredient);

    }
}
