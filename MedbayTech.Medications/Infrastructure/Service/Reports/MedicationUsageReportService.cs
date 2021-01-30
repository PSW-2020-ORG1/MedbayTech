using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Reports;
using MedbayTech.Medications.Domain.Entities.Reports;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
using MedbayTech.Medications.Application.Common.Interfaces.Service;

namespace MedbayTech.Medications.Infrastructure.Service.Reports
{
    public class MedicationUsageReportService : IMedicationUsageReportService
    {
        private IMedicationUsageReportRepository _medicationUsageReportRepository;
        private IMedicationUsageRepository _medicationUsageRepository;

        public MedicationUsageReportService(IMedicationUsageReportRepository reportRepository, IMedicationUsageRepository usageRepository)
        {
            _medicationUsageReportRepository = reportRepository;
            _medicationUsageRepository = usageRepository;
        }


        public MedicationUsageReport GenerateMedicationUsageReport(Period period)
        {
            char sep = Path.DirectorySeparatorChar;
            MedicationUsageReport report = new MedicationUsageReport(period.StartTime, period.EndTime);
            string filepath = "." + sep + "GeneratedUsageReports" + sep + report.Id + ".json";
            List<MedicationUsage> usages = _medicationUsageRepository.GetAll().ToList()
                .Where(ur => ur.InPeriod((DateTime)report.From, (DateTime)report.Until)).ToList();
            report.MedicationUsages.AddRange(usages);

            var jsonResolver = new MedicationUsageReportContractResolver();
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = jsonResolver;
            string json = JsonConvert.SerializeObject(report);
            Console.WriteLine(json);
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamWriter swriter = new StreamWriter(filepath))
            using (JsonWriter jwriter = new JsonTextWriter(swriter))
            {
                jsonSerializer.Serialize(jwriter, report);
            }
            return Add(report);
        }

        public MedicationUsageReport Add(MedicationUsageReport report) => 
            _medicationUsageReportRepository.Create(report);

        public bool Remove(MedicationUsageReport report) => 
            _medicationUsageReportRepository.Delete(report);

        public MedicationUsageReport Update(MedicationUsageReport report) =>
            _medicationUsageReportRepository.Update(report);

        public List<MedicationUsageReport> GetForSpecificPeriod(Period period) =>
            GetAll().ToList().FindAll(m => DateTime.Compare(m.From.GetValueOrDefault(DateTime.Now), period.StartTime) >= 0
            && DateTime.Compare(m.Until.GetValueOrDefault(DateTime.Now), period.EndTime) <= 0);

        public MedicationUsageReport Get(string id) =>
            _medicationUsageReportRepository.GetBy(id);
        public List<MedicationUsageReport> GetAll() =>
            _medicationUsageReportRepository.GetAll();
    }
}
