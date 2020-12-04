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
    public class CityTest
    {
        [Fact]
        public void Exists_by_id()
        {
            var stubRepository = CreateStubRepository();
            CityService cityService = new CityService(stubRepository);
            var city = CreateCityExists();

            var createdCity = cityService.CheckIfExists(city);

            createdCity.ShouldNotBeNull();
        }
        [Fact]
        public void Does_not_exists_by_id()
        {
            var stubRepository = CreateStubRepository();
            CityService cityService = new CityService(stubRepository);

            var city = CreateCityDoesNotExists();

            var createdCity = cityService.CheckIfExists(city);
           
            createdCity.ShouldBeNull();
        }

        [Fact]
        public void Save_city()
        {
            var stubRepository = CreateStubRepository();
            CityService cityService = new CityService(stubRepository);
            var city = CreateCityForSaving();

            var savedCity = cityService.Save(city);
            savedCity.ShouldNotBeNull();
        }

        public static ICityRepository CreateStubRepository()
        {
            var stubRepository = new Mock<ICityRepository>();
            var cities = CreateLisfOfCities();
            var city = CreateCityExists();

            stubRepository.Setup(p => p.GetAll()).Returns(cities);
            stubRepository.Setup(p => p.Create(city)).Returns(city);

            return stubRepository.Object;
        }

        private static List<City> CreateLisfOfCities()
        {
            List<City> cities = new List<City>();
            City city1 = new City
            {
                Id = 22000,
                Name = "Sremska Mitrovia"
            };
            City city2 = new City
            {
                Id = 11000,
                Name = "Beograd"
            };
            City city3 = new City
            {
                Id = 21000,
                Name = "Novi Sad"
            };
            cities.Add(city1);
            cities.Add(city2);
            cities.Add(city3);
            return cities;
        }

        private static City CreateCityExists()
        {
            return new City
            {
                Id = 22000,
                Name = "Sremska Mitrovia"
            };
        }

        private static City CreateCityDoesNotExists()
        {
            return new City
            {
                Id = 18000,
                Name = "Nis"
            };
        }

        private static City CreateCityForSaving()
        {
            return new City
            {
                Id = 11000,
                Name = "Beograd"
            };
        }
    }
}
