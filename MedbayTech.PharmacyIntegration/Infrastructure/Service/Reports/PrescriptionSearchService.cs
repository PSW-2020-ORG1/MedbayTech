
using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Application.DTO;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Reports
{
    public class PrescriptionSearchService : IPrescriptionSearchService
    {
        private readonly IPrescriptionGateway _prescriptionGateway;

        public PrescriptionSearchService(IPrescriptionGateway prescriptionGateway)
        {
            _prescriptionGateway = prescriptionGateway;
        }
        public List<PrescriptionForSendingDTO> GetAll() =>
            _prescriptionGateway.GetAll();
        public string GeneratePrescription(PrescriptionForSendingDTO prescription) =>
            _prescriptionGateway.GeneratePrescription(prescription);
    }
}
