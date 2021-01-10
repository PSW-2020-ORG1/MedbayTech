
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications
{
    public interface IMedicationService
    {

        Medication Add(Medication medication);
        List<Medication> GetAllMedicationsByNameOrId(string textSearchBox);
        Medication RejectMedication(Medication medication);
        List<Medication> GetAllMedicationByRoomId(string textSearchBox);
        Medication ApproveMedication(Medication medication);
        Medication CreateMedication(Medication medication);
        Medication UpdateMedication(Medication medication);
        bool DeleteMedication(Medication medication);
        Medication GetMedication(int id);
        List<Medication> GetAllOnValidation();
        List<Medication> GetAll();
        List<Medication> GetAllRejected();
        List<Medication> GetAllApproved();
        Medication AddAmount(Medication medication, int amount);
        Medication UpdateDosageOfIngredients(Medication medication, DosageOfIngredient dosageOfIngredient);

    }
}
