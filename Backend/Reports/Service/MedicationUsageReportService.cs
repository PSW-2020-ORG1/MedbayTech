using Backend.Reports.Model;
using Backend.Reports.Repository;
using Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Reports.Service
{
    public class MedicationUsageReportService
    {
        public IMedicationUsageReportRepository medicationUsageReportRepository;

        public MedicationUsageReportService(IMedicationUsageReportRepository medicationUsageReportRepository)
        {
            this.medicationUsageReportRepository = medicationUsageReportRepository;
        }

        public IEnumerable<MedicationUsageReport> GetAll() =>
            medicationUsageReportRepository.GetAll();

        public IEnumerable<MedicationUsageReport> GetForSpecificPeriod(Period period)
        {
            return medicationUsageReportRepository.GetAll().ToList().FindAll(m => DateTime.Compare(m.Period.StartTime, period.StartTime) >= 0 &&
                DateTime.Compare(m.Period.EndTime, period.EndTime) <= 0);
        }
            
    }
}
