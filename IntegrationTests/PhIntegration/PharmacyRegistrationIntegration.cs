using Microsoft.AspNetCore.Mvc;
using Moq;
using PharmacyIntegration.Controllers;
using PharmacyIntegration.Model;
using PharmacyIntegration.Repository;
using PharmacyIntegration.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace UnitTests.PhIntegrationTests
{
    public class PharmacyRegistrationIntegration
    {
        [Theory]
        [MemberData(nameof(RegistrationData))]
        public void Pharmacy_registration_integration_test(string pharmacyName, string apiKey, string endpoint, bool isOk)
        {
            PharmacyService pharmacyService = new PharmacyService(CreatePharmacyRepositoryStub());
            PharmacyController pharmacyController = new PharmacyController(pharmacyService);
            IActionResult result = pharmacyController.Post(new Pharmacy(pharmacyName, apiKey, endpoint));
            if(isOk)
            {
                result.ShouldBeOfType<OkResult>();
            }
            else
            {
                result.ShouldBeOfType<BadRequestResult>();
            }
        }

        public static IEnumerable<object[]> RegistrationData()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "Schnabel", "apisch123", "http://schnabel.herokuapp.com/pswapi/", true });
            retVal.Add(new object[] { "Jankovic", "apijan123", "http://jankovic.herokuapp.com/pswapi/", true });
            retVal.Add(new object[] { "Apoteka Srpskog Itebeja", "apiasi123", "http://asi.herokuapp.com/pswapi/", false });

            return retVal;
        }

        public IPharmacyRepository CreatePharmacyRepositoryStub()
        {
            var serviceStub = new Mock<IPharmacyRepository>();
            List<Pharmacy> pharmacies = GetPharmacies();
            serviceStub.Setup(s => s.Create(It.IsAny<Pharmacy>()))
                .Returns<Pharmacy>(p => pharmacies.FirstOrDefault(ph => ph.Id.Equals(p.Id)));
            return serviceStub.Object;
        }

        private List<Pharmacy> GetPharmacies()
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            pharmacies.Add(new Pharmacy("Schnabel", "apisch123", "http://schnabel.herokuapp.com/pswapi/"));
            pharmacies.Add(new Pharmacy("Jankovic", "apijan123", "http://jankovic.herokuapp.com/pswapi/"));
            pharmacies.Add(new Pharmacy("Limanac", "apilim123", "http://limanac.herokuapp.com/pswapi/"));

            return pharmacies;
        }
    }
}
