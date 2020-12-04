using Backend.Users.Repository.MySqlRepository;

using Backend.Users.WebApiService;
using Model.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Shouldly;

namespace MedbayTechUnitTests.Users
{
    public class AddressTest
    {

        [Fact]
        public void Exists_by_id()
        {
            var stubRepository = CreateStubRepository();
            AddressService addressService = new AddressService(stubRepository);
            var address = CreateAddressExists();

            Address isExists =  addressService.CheckIfExists(address);

            isExists.ShouldNotBeNull();
        }

        [Fact]
        public void Does_not_exists_by_id()
        {
            var stubRepository = CreateStubRepository();
            AddressService addressService = new AddressService(stubRepository);
            var address = CreateAddressDoesNotExists();

            Address isExists = addressService.CheckIfExists(address);

            isExists.ShouldBeNull();
        }
        [Fact]
        public void Save_address()
        {
            var stubRepository = CreateStubRepository();
            AddressService addressService = new AddressService(stubRepository);
            var address = CreateAddress();

            Address savedAddress = addressService.Save(address);

            savedAddress.ShouldNotBeNull();
        }
        public static IAddressRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IAddressRepository>();
            var addresses = CreateListOfAddresses();
            var address = CreateAddress();

            stubRepository.Setup(p => p.GetAll()).Returns(addresses);
            stubRepository.Setup(p => p.Create(address)).Returns(address);

            return stubRepository.Object;
        }
        private static List<Address> CreateListOfAddresses()
        {
            List<Address> addresses = new List<Address>();

            Address address1 = new Address { Id = 1, CityId=22000, Apartment = 0, Floor  = 0, Street = "Maksima gorkog" };
            Address address2 = new Address { Id = 2, CityId = 22000, Apartment = 0, Floor = 0, Street = "Radnicka 18" };
            
            addresses.Add(address1);
            addresses.Add(address2);

            return addresses;
        }

        private static Address CreateAddressDoesNotExists()
        {
            return new Address { Id = 3, CityId = 11000, Apartment = 0, Floor = 0, Street = "Gorspodara Vucica" };
        }

        private static Address CreateAddress()
        {
            Address address = new Address { Id = 1, CityId = 22000, Apartment = 0, Floor = 0, Street = "Maksima gorkog" };
            return address;
        }

        private static Address CreateAddressExists()
        {
            Address address = new Address { Id = 1, CityId = 22000, Apartment = 0, Floor = 0, Street = "Maksima gorkog" };
            return address;
        }


    }
}
