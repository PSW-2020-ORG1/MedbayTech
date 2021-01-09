

using MedbayTech.Pharmacies.Application.DTO;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways
{
    public interface IPrescriptionGateway
    {
        List<PrescriptionForSendingDTO> GetAll();
        string GeneratePrescription(PrescriptionForSendingDTO prescription);
    }
}
