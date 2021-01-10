using MedbayTech.Pharmacies.Application.DTO;
using System.Collections.Generic;


namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports
{
    public interface IPrescriptionSearchService
    {
        List<PrescriptionForSendingDTO> GetAll();
        string GeneratePrescription(PrescriptionForSendingDTO prescription);

    }
}
