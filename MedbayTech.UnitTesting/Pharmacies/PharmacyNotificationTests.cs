using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance;
using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using MedbayTech.Pharmacies.Infrastructure.Service.Pharmacies;
using Moq;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace MedbayTech.UnitTesting.Pharmacies
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
            pharmacies.Add(new Pharmacy("Jankovic", "jankovic123", "jankovic.rs", "jan@gmail.com", true));
            pharmacies.Add(new Pharmacy("Benu", "benu123", "benu.rs", "benu@gmail.com", false));
            pharmacies.Add(new Pharmacy("Zegin", "zegin123", "zegin.rs", "zegin@gmail.com", true));
            pharmacies.Add(new Pharmacy("Dan", "dan123", "dan.rs", "dan@gmail.com", false));
            pharmacies.Add(new Pharmacy("DM", "dm123", "dm.rs", "dm@gmail.com", true));

            stubRepository.Setup(s => s.GetAll()).Returns(pharmacies);

            stubRepository.Setup(s => s.GetBy("Jankovic")).Returns(pharmacies[0]);
            stubRepository.Setup(s => s.GetBy("Benu")).Returns(pharmacies[1]);
            stubRepository.Setup(s => s.GetBy("Zegin")).Returns(pharmacies[2]);
            stubRepository.Setup(s => s.GetBy("Dan")).Returns(pharmacies[3]);
            stubRepository.Setup(s => s.GetBy("DM")).Returns(pharmacies[4]);

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
