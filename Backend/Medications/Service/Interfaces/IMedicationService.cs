using Backend.Medications.Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

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

        /*IEnumerable<Medication> GetAllOnValidationFor(Doctor doctor);*/

        IEnumerable<Medication> GetAllOnValidation();

        IEnumerable<Medication> GetAll();

        IEnumerable<Medication> GetAllRejected();

        IEnumerable<Medication> GetAllApproved();

        Medication AddAmount(Medication medication, int amount);

        Medication UpdateSideEffects(Medication medication, SideEffect sideEffects);

        Medication UpdateDosageOfIngredients(Medication medication, DosageOfIngredient dosageOfIngredient);
        Medication UpdateAllergens(Medication medication, Allergens allergens);

    }
}
