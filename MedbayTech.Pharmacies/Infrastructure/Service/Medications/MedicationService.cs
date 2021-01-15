/***********************************************************************
 * Module:  MedicationService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicationService
 ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Domain.Enums;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Medications
{
    public class MedicationService : IMedicationService
    {
        //private readonly IMedicationRepository _medicationRepository;
        private readonly IMedicationGateway _medicationGateway;

        public MedicationService(IMedicationGateway medicationGateway)
        {
            _medicationGateway = medicationGateway;
        }

        public List<Medication> GetAllMedicationsByNameOrId(string query)
        {
            if (int.TryParse(query, out int id))
                return _medicationGateway.GetAll().Where(med => med.Id == id).ToList();
            return _medicationGateway.GetAll().Where(med => med.Med.ToLower().Contains(query.ToLower())).ToList();

        }

        public Medication UpdateMedicationDataBase(Medication medication)
        {
            var medicationToUpdate = _medicationGateway.GetBy(medication.Id);
            _medicationGateway.Update(medicationToUpdate.UpdateMedicationQuantity(medication));
            return medication;
        }

        public List<Medication> GetAllMedicationByRoomId(string query)
        {
            if (int.TryParse(query, out int id))
                return _medicationGateway.GetAll().Where(med => med.RoomId == id).ToList();
            return new List<Medication>();
        }

        public Medication RejectMedication(Medication medication)
        {
            medication.Status = MedStatus.Approved;
            return _medicationGateway.Update(medication);
        }

        public Medication ApproveMedication(Medication medication)
        {
            medication.Status = MedStatus.Rejected;
            return _medicationGateway.Update(medication);
        }

        public Medication CreateMedication(Medication medication)
        {
            Medication fullMedication = medication;
            _medicationGateway.Create(medication);

            return medication;
        }
        public Medication UpdateMedication(Medication medication)
        {
            var medicationToUpdate = _medicationGateway.GetBy(medication.Id);
            return _medicationGateway.Update(medicationToUpdate.UpdateMedicationQuantity(medication));
        }


        /*public bool DeleteMedication(Medication medication) =>
            _medicationRepository.Delete(medication);*/


        public Medication GetBy(int id) =>
            _medicationGateway.GetBy(id);


        /*public List<Medication> GetAllOnValidation() =>
            _medicationRepository.GetAllOnValidation();*/

        public List<Medication> GetAll() =>
            _medicationGateway.GetAll();

        /*public List<Medication> GetAllRejected() =>
            _medicationRepository.GetAllRejected();

        public List<Medication> GetAllApproved() =>
            _medicationRepository.GetAllApproved();*/

        public Medication AddAmount(Medication medication, int amount)
        {
            medication.Quantity += amount;
            return _medicationGateway.Update(medication);
        }

        public Medication UpdateDosageOfIngredients(Medication medication, DosageOfIngredient dosageOfIngredient)
        {
            medication.MedicationContent.Add(dosageOfIngredient);
            return _medicationGateway.Update(medication);
        }

        // NOTE(Jovan): For PHIntegration testing purposes
        public Medication Add(Medication medication) => _medicationGateway.Create(medication);

        public bool DeleteMedication(Medication medication)
        {
            throw new NotImplementedException();
        }

        public List<Medication> GetAllOnValidation()
        {
            throw new NotImplementedException();
        }

        public List<Medication> GetAllRejected()
        {
            throw new NotImplementedException();
        }

        public List<Medication> GetAllApproved()
        {
            throw new NotImplementedException();
        }
    }
}