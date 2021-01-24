using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Reports
{
    public class MedicationUsageReportService : IMedicationUsageReportService
    {

        private IMedicationUsageReportGateway _medicationUsageReportGateway;

        public MedicationUsageReportService(IMedicationUsageReportGateway medicationUsageReportGateway)
        {
            _medicationUsageReportGateway = medicationUsageReportGateway;
        }

        public List<MedicationUsageReport> GetAll()
            => _medicationUsageReportGateway.GetAll();
    }
}
