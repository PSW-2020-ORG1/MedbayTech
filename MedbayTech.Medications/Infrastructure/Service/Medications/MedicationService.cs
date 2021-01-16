using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications;
using MedbayTech.Medications.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Medications.Domain.Entities.Medications;
using MedbayTech.Medications.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Medications.Infrastructure.Service.Medications
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public List<Domain.Entities.Medications.Medication> GetAllMedicationsByNameOrId(string query)
        {
            if (int.TryParse(query, out int id))
                return _medicationRepository.GetAll().Where(med => med.Id == id).ToList();
            return _medicationRepository.GetAll().Where(med => med.Med.ToLower().Contains(query.ToLower())).ToList();
        }

        public List<Domain.Entities.Medications.Medication> GetAllMedicationByRoomId(string query)
        {
            if (int.TryParse(query, out int id))
                return _medicationRepository.GetAll().ToList().Where(med => med.RoomId == id).ToList();
            return new List<Domain.Entities.Medications.Medication>();
        }

        public Domain.Entities.Medications.Medication RejectMedication(Domain.Entities.Medications.Medication medication)
        {
            // TODO(Jovan): Shouldn't status be .Rejected?
            medication.Status = MedStatus.Approved;
            return _medicationRepository.Update(medication);
        }

        public Domain.Entities.Medications.Medication ApproveMedication(Domain.Entities.Medications.Medication medication)
        {
            // TODO(Jovan): Shouldn't status be .Approved?
            medication.Status = MedStatus.Rejected;
            return _medicationRepository.Update(medication);
        }

        public Domain.Entities.Medications.Medication UpdateMedication(Domain.Entities.Medications.Medication medication)
        {
            var medicationToUpdate = _medicationRepository.GetBy(medication.Id);
            return _medicationRepository.Update(medicationToUpdate.UpdateMedicationQuantity(medication));
        }

        public bool DeleteMedication(Domain.Entities.Medications.Medication medication) =>
            _medicationRepository.Delete(medication);


        public Domain.Entities.Medications.Medication GetMedication(int id) =>
            _medicationRepository.GetBy(id);


        public List<Domain.Entities.Medications.Medication> GetAllOnValidation() =>
            _medicationRepository.GetAllOnValidation();

        public List<Domain.Entities.Medications.Medication> GetAll() =>
            _medicationRepository.GetAll();

        public List<Domain.Entities.Medications.Medication> GetAllRejected() =>
            _medicationRepository.GetAllRejected();

        public List<Domain.Entities.Medications.Medication> GetAllApproved() =>
            _medicationRepository.GetAllApproved();

        public Domain.Entities.Medications.Medication AddAmount(Domain.Entities.Medications.Medication medication, int amount)
        {
            medication.Quantity += amount;
            return _medicationRepository.Update(medication);
        }

        public Domain.Entities.Medications.Medication UpdateDosageOfIngredients(Domain.Entities.Medications.Medication medication, DosageOfIngredient dosageOfIngredient)
        {
            medication.MedicationContent.Add(dosageOfIngredient);
            return _medicationRepository.Update(medication);
        }

        public Domain.Entities.Medications.Medication Add(Domain.Entities.Medications.Medication medication) =>
            _medicationRepository.Create(medication);
    }
}
