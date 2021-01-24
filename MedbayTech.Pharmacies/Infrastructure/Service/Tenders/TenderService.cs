using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Tenders
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly ITenderMedicationRepository _tenderMedicationRepository;

        public TenderService(ITenderRepository tenderRepository, ITenderMedicationRepository tenderMedicationRepository)
        {
            _tenderRepository = tenderRepository;
            _tenderMedicationRepository = tenderMedicationRepository;
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

        public List<TenderMedication> GetMedications(int tenderId)
        {
            return _tenderMedicationRepository.GetMedicationsForTender(tenderId);
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
