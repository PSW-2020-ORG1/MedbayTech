using Backend.Medications.Model;
using Backend.Reports.Model;
using Backend.Reports.Repository;
using Backend.Utils;
using Model;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Backend.Reports.Service
{
    public class MedicationUsageReportService : IMedicationUsageReportService
    {
        private MySqlContext _context;
        private IMedicationUsageReportRepository _repository;

        /*public MedicationUsageReportService(MySqlContext context)
        {
            this._context = context;
        }*/

        public MedicationUsageReportService(IMedicationUsageReportRepository repository)
        {
            _repository = repository;
        }


        public MedicationUsageReport GenerateMedicationUsageReport(Period period) 
        {
            // TODO(Jovan): Remove dummy data and implement report system
            string filepath = "." + Path.DirectorySeparatorChar + "report1.json";
            MedicationUsageReport report = new MedicationUsageReport(1, period.StartTime, period.EndTime);
            Specialization specialization = new Specialization(1, "DrugSpec");
            MedicationCategory category = new MedicationCategory("Drug", specialization);
            report.MedicationUsages.Add(new MedicationUsage(1, 4, new Medication("Aspirin 325mg", "Bayer", category)));
            report.MedicationUsages.Add(new MedicationUsage(2, 10, new Medication("Cyclopentanoperhydrophenanthrene 5mg", "StrongDrugs Inc.", category)));
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

        public MedicationUsageReport Add(MedicationUsageReport report) => _repository.Create(report);

        public bool Remove(MedicationUsageReport report) => _repository.Delete(report);

        public MedicationUsageReport Update(MedicationUsageReport report) => _repository.Update(report);

        public IEnumerable<MedicationUsageReport> GetForSpecificPeriod(Period period) =>
            GetAll().ToList().FindAll(m => DateTime.Compare(m.From.GetValueOrDefault(DateTime.Now), period.StartTime) >= 0
            && DateTime.Compare(m.Until.GetValueOrDefault(DateTime.Now), period.EndTime) <= 0);

        public MedicationUsageReport Get(int id) =>
            _repository.GetObject(id);
        public IEnumerable<MedicationUsageReport> GetAll() =>
            _repository.GetAll();
    }
}
