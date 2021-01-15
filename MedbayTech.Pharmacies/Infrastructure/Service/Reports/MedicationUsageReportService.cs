using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Reports;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Rooms;
using MedbayTech.Pharmacies.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MedbayTech.Pharmacies.Infrastructure.Service.Reports
{
    public class MedicationUsageReportService : IMedicationUsageReportService
    {
        private IMedicationUsageReportGateway _medicationUsageReportGateway;
        private IMedicationUsageGateway _medicationUsageGateway;

        public MedicationUsageReportService(IMedicationUsageReportGateway medicationUsageReportGateway, IMedicationUsageGateway medicationUsageGateway)
        {
            _medicationUsageReportGateway = medicationUsageReportGateway;
            _medicationUsageGateway = medicationUsageGateway;
        }


        public MedicationUsageReport GenerateMedicationUsageReport(Period period)
        {
            return _medicationUsageReportGateway.Generate(period);
        }

        public MedicationUsageReport Add(MedicationUsageReport report) => _medicationUsageReportGateway.Add(report);

        public List<MedicationUsageReport> GetForSpecificPeriod(Period period) =>
            GetAll().ToList().FindAll(m => DateTime.Compare(m.From.GetValueOrDefault(DateTime.Now), period.StartTime) >= 0
            && DateTime.Compare(m.Until.GetValueOrDefault(DateTime.Now), period.EndTime) <= 0);

        public MedicationUsageReport Get(string id) =>
            _medicationUsageReportGateway.GetBy(id);
        public List<MedicationUsageReport> GetAll() =>
            _medicationUsageReportGateway.GetAll();
    }
}
