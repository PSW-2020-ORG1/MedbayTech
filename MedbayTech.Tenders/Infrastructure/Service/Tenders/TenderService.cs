using MedbayTech.Tenders.Application.Common.Interfaces.Gateways;
using MedbayTech.Tenders.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Tenders.Application.DTO;
using MedbayTech.Tenders.Domain.Entities.Medications;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using System;
using System.Collections.Generic;

namespace MedbayTech.Tenders.Infrastructure.Service.Tenders
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly ITenderMedicationRepository _tenderMedicationRepository;
        private readonly IMedicationGateway _medicationGateway;

        public TenderService(ITenderRepository tenderRepository, ITenderMedicationRepository tenderMedicationRepository,
            IMedicationGateway medicationGateway)
        {
            _tenderRepository = tenderRepository;
            _tenderMedicationRepository = tenderMedicationRepository;
            _medicationGateway = medicationGateway;
        }

        public Tender Add(Tender tender) => _tenderRepository.Create(tender);

        public TenderMedication CreateMedicationForTender(int tenderId, TenderMedicationDTO medicationDTO)
        {
            TenderMedication tenderMedication = new TenderMedication(medicationDTO, tenderId);
            return _tenderMedicationRepository.Create(tenderMedication);
        }

        public Tender CreateTender(TenderDTO tenderDTO)
        {
            Tender tender = new Tender(tenderDTO);
            return _tenderRepository.Create(tender);

        }

        public Tender Get(int id) => _tenderRepository.GetBy(id);


        public List<Tender> GetAll() => _tenderRepository.GetAll();

        public List<TenderMedicationDTO> GetMedications(int tenderId)
        {
            Medication medication;
            List<TenderMedicationDTO> tenderMedicationDTOs = new List<TenderMedicationDTO>();
            List<TenderMedication> tenderMedications = _tenderMedicationRepository.GetMedicationsForTender(tenderId);
            List<Medication> allMedications = _medicationGateway.GetAll();

            foreach (TenderMedication tenderMedication in tenderMedications)
            {
                medication = allMedications.Find(m => m.Id.Equals(tenderMedication.MedicationId));
                if (medication != null)
                {
                    tenderMedicationDTOs.Add(new TenderMedicationDTO(medication.Id, medication.Med, medication.Dosage, tenderMedication.TenderMedicationQuantity));
                }
            }
            return tenderMedicationDTOs;
        }


        public bool Remove(Tender tender)
        {
            return _tenderRepository.Delete(tender);
        }

        public Tender Update(Tender tender)
        {
            return _tenderRepository.Update(tender);
        }
    }
}
