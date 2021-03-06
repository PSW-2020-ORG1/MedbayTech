﻿using System.Collections.Generic;
using MedbayTech.Tenders.Application.DTO;
using MedbayTech.Tenders.Domain.Entities.Tenders;

namespace MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders
{
    public interface ITenderService
    {
        Tender Add(Tender tender);
        bool Remove(Tender tender);
        Tender Update(Tender tender);
        Tender Get(int id);
        List<Tender> GetAll();
        List<TenderMedicationDTO> GetMedications(int tenderId);
        Tender CreateTender(TenderDTO tenderDTO);
        TenderMedication CreateMedicationForTender(int tenderId, TenderMedicationDTO medicationDTOs);
    }
}
