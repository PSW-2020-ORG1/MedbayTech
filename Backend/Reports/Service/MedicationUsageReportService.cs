using Backend.Reports.Model;
using Backend.Reports.Repository;
using Backend.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backend.Reports.Service
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
            // TODO(Jovan): Remove dummy data and implement report system
            char sep = Path.DirectorySeparatorChar;
            MedicationUsageReport report = new MedicationUsageReport(period.StartTime, period.EndTime);
            string filepath = "." + sep + "GeneratedUsageReports" + sep + report.Id + ".json";
            List<MedicationUsage> usages = (List<MedicationUsage>)_medicationUsageRepository.GetAll().ToList()
                .Where(ur => ur.InPeriod((DateTime)report.From, (DateTime)report.Until)).ToList();
            report.MedicationUsages.AddRange(usages);
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

        public MedicationUsageReport Add(MedicationUsageReport report) => _medicationUsageReportRepository.Create(report);

        public bool Remove(MedicationUsageReport report) => _medicationUsageReportRepository.Delete(report);

        public MedicationUsageReport Update(MedicationUsageReport report) => _medicationUsageReportRepository.Update(report);

        public IEnumerable<MedicationUsageReport> GetForSpecificPeriod(Period period) =>
            GetAll().ToList().FindAll(m => DateTime.Compare(m.From.GetValueOrDefault(DateTime.Now), period.StartTime) >= 0
            && DateTime.Compare(m.Until.GetValueOrDefault(DateTime.Now), period.EndTime) <= 0);

        public MedicationUsageReport Get(string id) =>
            _medicationUsageReportRepository.GetObject(id);
        public IEnumerable<MedicationUsageReport> GetAll() =>
            _medicationUsageReportRepository.GetAll();
    }
}
