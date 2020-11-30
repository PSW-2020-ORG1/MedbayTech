using Backend.Medications.Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Medications.Service
{
    public interface IMedicationService
    {
        public List<Medication> GetAllMedicationsByNameOrId(string textSearchBox);
        public Medication RejectMedication(Medication medication);

        public Medication ApproveMedication(Medication medication);

        public Medication CreateMedication(Medication medication);

        public Medication UpdateMedication(Medication medication);

        public bool DeleteMedication(Medication medication);
        public Medication GetMedication(int id);

        public IEnumerable<Medication> GetAllOnValidationFor(Doctor doctor);

        public IEnumerable<Medication> GetAllOnValidation();

        public IEnumerable<Medication> GetAll();

        public IEnumerable<Medication> GetAllRejected();

        public IEnumerable<Medication> GetAllApproved();

        public Medication AddAmount(Medication medication, int amount);

        public Medication UpdateSideEffects(Medication medication, SideEffect sideEffects);

        public Medication UpdateDosageOfIngredients(Medication medication, DosageOfIngredient dosageOfIngredient);
        public Medication UpdateAllergens(Medication medication, Allergens allergens);
    }
}
