using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Reports;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System.Collections.Generic;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Reports
{
    public class MedicationUsageService : IMedicationUsageService
    {

        private IMedicationUsageGateway _medicationUsageGateway;
        public MedicationUsageService(IMedicationUsageGateway medicationUsageGateway)
        {
            _medicationUsageGateway = medicationUsageGateway;
        }

        public MedicationUsage Add(MedicationUsage medicationUsage) => _medicationUsageGateway.Add(medicationUsage);
       

        public MedicationUsage Get(int id) => _medicationUsageGateway.GetBy(id);

        public List<MedicationUsage> GetAll() => _medicationUsageGateway.GetAll();
    }
}
