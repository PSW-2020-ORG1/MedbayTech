using System;
using System.Collections.Generic;
using System.Text;
using Backend.Reports.Service;
using Moq;
using PharmacyIntegration.Model;
using PharmacyIntegration.Repository;
using PharmacyIntegration.Service;
using Shouldly;
using Xunit;

namespace MedbayTechUnitTests.PhIntegrationTests
{
    public class PharmacyNotificationTests
    {
        [Theory]
        [MemberData(nameof(NotificationFrom))]
        public void Check_does_pharmacy_have_permission_to_send_notification(string pharmacyId, bool doesHavePermission)
        {
            PharmacyNotificationService pharmacyNotificationService =
                new PharmacyNotificationService(CreatePharmacyNotificationStubRepository(), CreatePharmacyStubRepository());

            bool permission = pharmacyNotificationService.CheckPermisionToSendNotification(pharmacyId);

            permission.ShouldBe(doesHavePermission);
        }

        public static IEnumerable<object[]> NotificationFrom()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "Jankovic", true });
            retVal.Add(new object[] { "Benu", false });
            retVal.Add(new object[] { "Zegin", true });
            retVal.Add(new object[] { "Dan", false });
            retVal.Add(new object[] { "DM", true });
            retVal.Add(new object[] { "Zelena Apoteka", false });

        return retVal;
        }

        private static IPharmacyRepository CreatePharmacyStubRepository()
        {
            var stubRepository = new Mock<IPharmacyRepository>();
            List<Pharmacy> pharmacies = new List<Pharmacy>();
                pharmacies.Add(new Pharmacy("Jankovic", "jankovic123", "jankovic.rs", true));
                pharmacies.Add(new Pharmacy("Benu", "benu123", "benu.rs", false));
                pharmacies.Add(new Pharmacy("Zegin", "zegin123", "zegin.rs", true));
                pharmacies.Add(new Pharmacy("Dan", "dan123", "dan.rs", false));
                pharmacies.Add(new Pharmacy("DM", "dm123", "dm.rs", true));

            stubRepository.Setup(s => s.GetAll()).Returns(pharmacies);

            stubRepository.Setup(s => s.GetObject("Jankovic")).Returns(pharmacies[0]);
            stubRepository.Setup(s => s.GetObject("Benu")).Returns(pharmacies[1]);
            stubRepository.Setup(s => s.GetObject("Zegin")).Returns(pharmacies[2]);
            stubRepository.Setup(s => s.GetObject("Dan")).Returns(pharmacies[3]);
            stubRepository.Setup(s => s.GetObject("DM")).Returns(pharmacies[4]);

            return stubRepository.Object;
        }

        private static IPharmacyNotificationRepository CreatePharmacyNotificationStubRepository()
        {
            var stubRepository = new Mock<IPharmacyNotificationRepository>();
            var notifications = new List<PharmacyNotification>();

            notifications.Add(new PharmacyNotification("Sale!!!", "Jankovic"));

            stubRepository.Setup(m => m.GetAll()).Returns(notifications);
            return stubRepository.Object;
        }

    }
}
