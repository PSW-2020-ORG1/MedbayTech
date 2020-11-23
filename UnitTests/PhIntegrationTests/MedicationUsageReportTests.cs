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
        public void Analyze_usage_in_specific_period(Period period, bool isEmpty)
        {
            MedicationUsageReportService medicationUsageReportService = new MedicationUsageReportService(CreateStubRepository());

            List<MedicationUsageReport> reports = (List<MedicationUsageReport>)medicationUsageReportService.GetForSpecificPeriod(period);

            reports.IsNullOrEmpty().ShouldBe(isEmpty);
        }

        public static IEnumerable<object[]> Periods()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Period(new DateTime(2020, 8, 10), new DateTime(2020, 9, 10)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 8, 10), new DateTime(2020, 9, 10)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 8, 10), new DateTime(2020, 9, 10)), false });
            retVal.Add(new object[] { new Period(new DateTime(2020, 8, 10), new DateTime(2020, 9, 10)), false });
            return retVal;
        }

        private static IMedicationUsageReportRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicationUsageReportRepository>();
            var medicationUsageReports = new List<MedicationUsageReport>();

            var medicationUsageReport1 = new MedicationUsageReport(001, new Period(new DateTime(2020, 8, 10), new DateTime(2020, 9, 10)));
            medicationUsageReport1.Medications.Add(new Medication("Brufen", "Galenika", new MedicationCategory()));
            medicationUsageReport1.Medications.Add(new Medication("Aspirin", "Bayern", new MedicationCategory()));
            medicationUsageReport1.Medications.Add(new Medication("Bromazepam", "Hemofarm", new MedicationCategory()));

            medicationUsageReports.Add(medicationUsageReport1);

            stubRepository.Setup(m => m.GetAll()).Returns(medicationUsageReports);
            return stubRepository.Object;
        }
    }
}
