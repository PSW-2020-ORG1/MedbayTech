using Backend.Medications.Model;
using System.Collections.Generic;

namespace Backend.Medications.Service
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

        Medication UpdateSideEffects(Medication medication, SideEffect sideEffects);

        Medication UpdateDosageOfIngredients(Medication medication, DosageOfIngredient dosageOfIngredient);
        Medication UpdateAllergens(Medication medication, Allergens allergens);

    }
}
