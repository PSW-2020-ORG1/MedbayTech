using System.Collections.Generic;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Tenders
{
    public interface ITenderService
    {
        Tender Add(Tender tender);
        bool Remove(Tender tender);
        Tender Update(Tender tender);
        Tender Get(int id);
        List<Tender> GetAll();
        List<TenderMedication> GetMedications(int tenderId);
        Tender CreateTender(TenderDTO tenderDTO);
        TenderMedication CreateMedicationForTender(int tenderId, TenderMedicationDTO medicationDTOs);
    }
}
