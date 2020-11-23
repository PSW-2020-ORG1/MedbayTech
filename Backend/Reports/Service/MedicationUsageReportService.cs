using Backend.Reports.Model;
using Backend.Reports.Repository;
using System;
using System.Collections.Generic;
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

    }
}
