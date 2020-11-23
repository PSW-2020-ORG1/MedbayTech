using Backend.Reports.Model;
using Backend.Reports.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Reports.Controller
{
    public class MedicationUsageReportController
    {
        public MedicationUsageReportService medicationUsageReportService;

        public MedicationUsageReportController(MedicationUsageReportService medicationUsageReportService)
        {
            this.medicationUsageReportService = medicationUsageReportService;

        }

        public IEnumerable<MedicationUsageReport> GetAll() =>
            medicationUsageReportService.GetAll();

    }
}
