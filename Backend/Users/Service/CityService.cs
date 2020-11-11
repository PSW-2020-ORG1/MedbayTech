// File:    CityService.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 4:38:35 AM
// Purpose: Definition of Class CityService

using Model.Users;
using Repository;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;

namespace Service.GeneralService
{
   public class CityService
   {
        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public IEnumerable<City> GetAllCitiesByState(State state) => cityRepository.GetAllCitiesByState(state);

        public City CreateCity(City city) => cityRepository.Create(city);

        public City GetCityByName(City city) => cityRepository.GetCityByName(city);

        public IEnumerable<City> GetAll() => cityRepository.GetAll();

        public bool CheckIfExists(City city) => cityRepository.CheckIfExists(city);

        public ICityRepository cityRepository;
   
   }
}