using Backend.Medications.Model;
using Backend.Reports.Model;
using Backend.Reports.Repository;
using Backend.Reports.Service;
using Backend.Utils;
using Castle.Core.Internal;
using Model.Users;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests.PhIntegrationTests
{
    public class MedicationUsageReportTests
    {
        [Theory]
        [MemberData(nameof(Periods))]
        public void Analyze_reports_in_specific_period(Period period, bool isEmpty)
        {
            MedicationUsageReportService medicationUsageReportService = new MedicationUsageReportService(CreateStubRepository());

            List<MedicationUsageReport> reports = (List<MedicationUsageReport>)medicationUsageReportService.GetForSpecificPeriod(period);

            reports.IsNullOrEmpty().ShouldBe(isEmpty);
        }

        [Theory]
        [MemberData(nameof(UsagePeriods))]
        public void Analyze_usage_in_specific_period(Period period, bool isEmpty)
        {
            MedicationUsageReportService medicationUsageReportService = new MedicationUsageReportService(CreateStubRepository());

            List<MedicationUsageReport> reports = (List<MedicationUsageReport>)medicationUsageReportService.GetForSpecificPeriod(period);

            isEmptyUsage(reports).ShouldBe(isEmpty);
        }

        public static IEnumerable<object[]> Periods()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Period(new DateTime(2020, 8, 15), new DateTime(2020, 9, 10)), true });
            retVal.Add(new object[] { new Period(new DateTime(2020, 7, 11), new DateTime(2020, 8, 5)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 1, 25), new DateTime(2020, 2, 12)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 3, 8), new DateTime(2020, 4, 30)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 1, 1), new DateTime(2020, 1, 2)), true });
            return retVal;
        }

        public static IEnumerable<object[]> UsagePeriods()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Period(new DateTime(2020, 8, 15), new DateTime(2020, 9, 10)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 7, 11), new DateTime(2020, 8, 5)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 1, 25), new DateTime(2020, 2, 12)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 3, 8), new DateTime(2020, 4, 30)), true });
            retVal.Add(new object[] { new Period(new DateTime(2020, 1, 1), new DateTime(2020, 1, 2)), false });
            return retVal;
        }

        private static IMedicationUsageReportRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicationUsageReportRepository>();
            var medicationUsageReports = new List<MedicationUsageReport>();

            var medicationUsageReport1 = new MedicationUsageReport(810910, new Period(new DateTime(2020, 8, 10), new DateTime(2020, 9, 10)));
            medicationUsageReport1.Medications.Add(new Medication("Brufen", "Galenika", new MedicationCategory()));
            medicationUsageReport1.Medications.Add(new Medication("Aspirin", "Bayern", new MedicationCategory()));
            medicationUsageReport1.Medications.Add(new Medication("Bromazepam", "Hemofarm", new MedicationCategory()));

            var medicationUsageReport2 = new MedicationUsageReport(71185, new Period(new DateTime(2020, 7, 11), new DateTime(2020, 8, 5)));
            medicationUsageReport2.Medications.Add(new Medication("Bensedin", "Galenika", new MedicationCategory()));
            medicationUsageReport2.Medications.Add(new Medication("Xanax", "Bayern", new MedicationCategory()));

            var medicationUsageReport3 = new MedicationUsageReport(125212, new Period(new DateTime(2020, 1, 25), new DateTime(2020, 2, 12)));
            medicationUsageReport3.Medications.Add(new Medication("Tylol hot", "Richter Gedeon", new MedicationCategory()));
            medicationUsageReport3.Medications.Add(new Medication("Panadol", "Bayern", new MedicationCategory()));
            medicationUsageReport3.Medications.Add(new Medication("Paracetamol", "Hemofarm", new MedicationCategory()));
            medicationUsageReport3.Medications.Add(new Medication("Pressing", "Hemofarm", new MedicationCategory()));

            var medicationUsageReport4 = new MedicationUsageReport(39430, new Period(new DateTime(2020, 3, 9), new DateTime(2020, 4, 30)));

            medicationUsageReports.Add(medicationUsageReport1);
            medicationUsageReports.Add(medicationUsageReport2);
            medicationUsageReports.Add(medicationUsageReport3);
            medicationUsageReports.Add(medicationUsageReport4);

            stubRepository.Setup(m => m.GetAll()).Returns(medicationUsageReports);
            return stubRepository.Object;
        }

        public static bool isEmptyUsage(List<MedicationUsageReport> reports)
        {
            foreach (MedicationUsageReport report in reports)
            {
                if (report.Medications.IsNullOrEmpty())
                    return true;
            }
            return false;
        }
    }
}
