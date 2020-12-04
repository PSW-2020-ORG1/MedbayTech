using Backend.Users.Repository.MySqlRepository;
using Backend.Users.Service.Interfaces;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class CityService : ICityService
    {
        ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public City Save(City cityToSave)
        {
            City city = CheckIfExists(cityToSave);
            if (city == null)
            {
                return cityRepository.Create(cityToSave);
            }
            return city;
        }

        public City CheckIfExists(City city)
        {
            List<City> cities = cityRepository.GetAll().ToList();
            bool exists = cities.Any(c => c.Id == city.Id);
            if(exists)
            {
                return cities.FirstOrDefault(c => c.Id == city.Id);
            }
            return null;

        }
    }
}
